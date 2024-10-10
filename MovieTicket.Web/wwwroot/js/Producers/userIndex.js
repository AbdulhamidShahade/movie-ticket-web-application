function togglePopup() {
    const popup = document.getElementById('popup');
    popup.classList.toggle('hidden');
}

function showMovieData(producerFirstName, producerLastName, producerBio, producerBirthDate, producerId, producerPicture, country) {

    document.getElementById('producer-name').innerText = producerFirstName + " " + producerLastName;
    document.getElementById('producer-bio').innerHTML = "<strong>Bio: </strong>" + producerBio
    document.getElementById('producer-birth-date').innerHTML = "<strong>Birth Date: </strong>" + producerBirthDate;
    document.getElementById('producer-details').setAttribute('href', `/Producers/Details/${producerId}`);
    document.getElementById('producer-picture').setAttribute('src', producerPicture);
    document.getElementById('producer-movies').setAttribute('href', `/Producers/MoviesByActor/${producerId}`);
    document.getElementById('country-name').innerText = country;

    togglePopup();
}