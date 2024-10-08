function togglePopup() {
    const popup = document.getElementById('popup');
    popup.classList.toggle('hidden');
}

function showMovieData(actorFirstName, actorLastName, actorBio, actorBirthDate, actorId, actorPicture, country) {

    document.getElementById('actor-name').innerText = actorFirstName + " " + actorLastName;
    document.getElementById('actor-bio').innerHTML = "<strong>Bio: </strong>" + actorBio
    document.getElementById('actor-birth-date').innerHTML = "<strong>Birth Date: </strong>" + actorBirthDate;
    document.getElementById('actor-details').setAttribute('href', `/Actors/Details/${actorId}`);
    document.getElementById('actor-picture').setAttribute('src', actorPicture);
    document.getElementById('actor-movies').setAttribute('href', `/Actors/MoviesByActor/${actorId}`);
    document.getElementById('country-name').innerText = country;

    togglePopup();
}