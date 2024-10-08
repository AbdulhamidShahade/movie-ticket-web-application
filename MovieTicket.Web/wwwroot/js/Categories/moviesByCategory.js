function togglePopup() {
    const popup = document.getElementById('popup');
    popup.classList.toggle('hidden');
}

function showMovieData(movieName, movieDescription, startDate, endDate, movieId, moviePicture, price, cinemaName, publishYear, length, categoryNames, rating) {

    document.getElementById('movie-publish-year-length').innerText = publishYear + ' • ' + Math.floor(length / 60) + ' h ' + (length % 60) + ' minutes • R';
    document.getElementById('movie-name').innerText = movieName;
    document.getElementById('movie-bio').innerHTML = "<strong>Description: </strong> " + movieDescription;
    document.getElementById('movie-start-date').innerHTML = "<strong>Start Date:</strong> " + startDate;
    document.getElementById('movie-end-date').innerHTML = "<strong>End Date:</strong> " + endDate;
    document.getElementById('movie-details').setAttribute('href', `https://localhost:7173/Movies/Details/${movieId}`);
    document.getElementById('movie-picture').setAttribute('src', moviePicture);
    document.getElementById('shopping-cart').setAttribute('href', `https://localhost:7173/Orders/AddItemToShoppingCart/${movieId}`);
    document.getElementById('shopping-cart').innerHTML = `<i class="bi bi-cart-plus"></i> Add to Cart (Price ${price.toLocaleString('en-US', { style: 'currency', currency: 'USD' })})`;
    document.getElementById('cinema-name').innerHTML = "<strong>Cinema: </strong>" + cinemaName;
    document.getElementById('movie-category').innerText = categoryNames;
    document.getElementById('movie-rating').innerText = rating + '/10';

    togglePopup();
}