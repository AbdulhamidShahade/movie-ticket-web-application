﻿namespace MovieTicket.Web.Models.ViewModels.MovieVM
{
    public class UpdateMovieVM : CreateMovieVM
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}