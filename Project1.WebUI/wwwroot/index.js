'use strict';

const userLogin = document.getElementById('user-login');
const userLoginForm = document.getElementById('user-login-form');
const loginError = document.getElementById('login-error');



// Login Handler
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


// Main Menu Handlers
const menu = document.getElementById('menu');
const createCustomer = document.getElementById('create-customer');
const searchCustomers = document.getElementById('search-customers');
const createOrder1 = document.getElementById('create-order');
const searchOrders = document.getElementById('search-orders');

const createCustomerMenu = document.getElementById('create-customer-menu');
const searchCustomersMenu = document.getElementById('search-customers-menu');


createCustomer.addEventListener('click', event => {
  menu.hidden = true;
  createCustomerMenu.hidden = false;
});

searchCustomers.addEventListener('click', event => {
  let customers = loadCustomerList();

  searchCustomersForm.elements['customer-select'].innerHTML = '';
  for(let i = 0; i < customers.length; i++) {
    console.info(customers[i]);
    searchCustomersForm.elements['customer-select'].innerHTML += `<option value="${i}">${customers[i].FirstName} ${customers[i].LastName}</option>`;
  }

  menu.hidden = true;
  searchCustomersMenu.hidden = false;
});

createOrder1.addEventListener('click', event => {

});

searchOrders.addEventListener('click', event => {

});


// Create Customer Menu Handlers
const createCustomerForm = document.getElementById("create-customer-form");
const createCustomerResult = document.getElementById("create-customer-result");

createCustomerForm.addEventListener('submit', event => {
  // don't use ordinary form submission, because the server would need
  // to both process the data and respond with HTML, and for now
  // we can only do one at a time (process data in a controller, or
  // send a static file matching the URL)
  event.preventDefault();

  const details = {
    FirstName: createCustomerForm.elements['firstname'].value,
    LastName: createCustomerForm.elements['lastname'].value,
    Address: createCustomerForm.elements['address'].value,
    City: createCustomerForm.elements['city'].value,
    State: createCustomerForm.elements['state'].value,
    Country: createCustomerForm.elements['country'].value,
    PostalCode: createCustomerForm.elements['postalcode'].value,
    Phone: createCustomerForm.elements['phone'].value,
    Email: createCustomerForm.elements['email'].value
  }

  createUser(details).then(result => {
    console.info(result);
    if (result == true) {
      createCustomerForm.hidden = true;
      createCustomerResult.hidden = false;
      createCustomerResult.textContent = "Customer created successfully."
      setTimeout(() => {
        createCustomerMenu.hidden = true;
        menu.hidden = false;
      }, 2000)
    }
  });
});

createCustomerForm.elements['cancel'].addEventListener('click', event => {
  createCustomerMenu.hidden = true;
  menu.hidden = false;
});


// Search Customers Menu Handlers
const searchCustomersForm = document.getElementById("search-customers-form");
const searchCustomersDisplay = document.getElementById("search-customers-display");

searchCustomersForm.addEventListener('change', event => {
  // don't use ordinary form submission, because the server would need
  // to both process the data and respond with HTML, and for now
  // we can only do one at a time (process data in a controller, or
  // send a static file matching the URL)
  event.preventDefault();

  let customer = loadUserDetails()
});

searchCustomersForm.elements['cancel'].addEventListener('click', event => {
  searchCustomersMenu.hidden = true;
  menu.hidden = false;
});

