'use strict';

const userDisplay = document.getElementById('user-display');
const errorMessage = document.getElementById('error-message');
const username = undefined;
const password = undefined;


loginUser(username, password)
  .then(loginSuccess => {
    if (loginSuccess == true)
    {
      sessionStorage.setItem("username", username);
    }
  })
  .catch(error => {
    errorMessage.textContent = error.toString();
    errorMessage.hidden = false;
  });

