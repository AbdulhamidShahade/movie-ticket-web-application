﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Web.Models;
using MovieTicket.Web.Models.ViewModels;
using MovieTicket.Web.Repositories.IRepository;
using System.Security.Claims;

namespace MovieTicketWebApplication.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrdersController(IOrderRepository orderRepository, IMovieRepository movieRepository, ShoppingCart shoppingCart, UserManager<ApplicationUser> userManager)
        {
            _orderRepository = orderRepository;
            _movieRepository = movieRepository;
            _shoppingCart = shoppingCart;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            string emailAddress = User.FindFirstValue(ClaimTypes.Email);
            int userId = _userManager.FindByEmailAsync(emailAddress).GetAwaiter().GetResult().Id;
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _orderRepository.GetOrdersAsync(userId, userRole);

            return View(orders);
        }

        public async Task<IActionResult> ShoppingCart()
        {
            var items = await _shoppingCart.GetAllShoppingCartItemsAsync();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
            };

            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _movieRepository.GetAsync(x => x.Id == id);

            if (item != null)
            {
                await _shoppingCart.AddItemToCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }


        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _movieRepository.GetAsync(x => x.Id == id, c => c.Cinema);

            if (item != null)
            {
                await _shoppingCart.RemoveItemFromCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }


        public async Task<IActionResult> CompleteOrder()
        {
            var items = await _shoppingCart.GetAllShoppingCartItemsAsync();
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);
            int userId = _userManager.FindByEmailAsync(userEmailAddress).GetAwaiter().GetResult().Id;

            await _orderRepository.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}