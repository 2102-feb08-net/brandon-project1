'use strict';

const userLogin = document.getElementById('user-login');
const userLoginForm = document.getElementById('user-login-form')
const loginError = document.getElementById('login-error');

const menu = document.getElementById('menu');

userLogin.addEventListener('submit', event => {
  // don't use ordinary form submission, because the server would need
  // to both process the data and respond with HTML, and for now
  // we can only do one at a time (process data in a controller, or
  // send a static file matching the URL)
  event.preventDefault();

  let username = userLoginForm.elements['username'].value;
  let password = userLoginForm.elements['password'].value;

  loginUser(username, password)
    .then(loginSuccess => {
      if (loginSuccess == true)
      {
        sessionStorage.setItem("username", username);
      }
      userLogin.hidden = true;
      menu.hidden = false;
    })
    .catch(error => {
      loginError.textContent = error.toString();
      loginError.hidden = false;
    });
});
