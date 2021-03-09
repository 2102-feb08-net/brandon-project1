'use strict';

/***************************************************************************
 *  User Requests
 */



// send a request that will be handled by UserController.Check based on the
// route configured with attributes (/api/user/check)
function checkUser(username) {
  return fetch(`api/user/check?username=${username}`).then(response => {
    if (!response.ok) {
      throw new Error(`Network response was not ok (${response.status})`);
    }
    return response.json();
  });
}


// send a request that will be handled by UserController.Login based on the
// route configured with attributes (/api/user/login)
function loginUser(username, password) {
  return fetch(`api/user/login?username=${username}&password=${password}`).then(response => {
    if (response.status == 404) {
      throw new Error(`Username or password was invalid.`);
    }
    if (!response.ok) {
      throw new Error(`Network response was not ok (${response.status})`);
    }
    return true;
  });
}


// send a request that will be handled by UserController.Details based on
// route configured with attributes (/api/user/details)
function loadUserDetails() {
  let username = sessionStorage.getItem("username")
  if (username != null)
  {
    return fetch(`api/user/details?username=${username}`).then(response => {
      if (!response.ok) {
        throw new Error(`Network response was not ok (${response.status})`);
      }
      return response.json();
    });
  }
}


// send a request that will be handled by UserController.Create based on the
// route configured with attributes and in the body (/api/user/create)
function createUser(username, password, details) {
  const user = {
    Username: username,
    Password: password
  };
  const customer = {
    FirstName: details.FirstName,
    LastName: details.LastName,
    Address: details.Address,
    City: details.City,
    State: details.State,
    Country: details.Country,
    PostalCode: details.PostalCode,
    Phone: details.Phone,
    Email: details.Email
  }
  
  return fetch(`api/user/create?username=${username}&password=${password}`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: concat(JSON.stringify(customer))
  }).then(response => {
    if (!response.ok) {
      throw new Error(`Network response was not ok (${response.status})`);
    }
  });
}



/*****************************************************************************
 *  Order Requests
 */



// send a request that will be handled by OrderController.Details based on the
// route configured with attributes (/api/order/details)
function loadOrderDetails(orderId) {
  return fetch(`api/order/details?orderId=${orderId}`).then(response => {
    if (!response.ok) {
      throw new Error(`Network response was not ok (${response.status})`);
    }
    return response.json();
  });
}


// send a request that will be handled by OrderController.Create based on the
// route data configured in the body (/api/order/create)
function createOrder(orderIn, orderLinesIn) {
  if (orderLinesIn.length <= 0)
  {
    throw new Error(`Attempt to create Order with no OrderLines`);
  }
  const lines = [];
  for (let i = 0; i < orderLinesIn.length; i++) {
    lines[i] = {
      ProductId: orderLinesIn[i].ProductId,
      Quantity: orderLinesIn[i].Quantity
    };
  }
  const order = {
    CustomerId: orderIn.CustomerId,
    LocationId: orderIn.LocationId,
    OrderTime: orderIn.OrderTime,
    OrderLines: lines
  }

  return fetch(`api/order/create`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: concat(JSON.stringify(order))
  }).then(response => {
    if (!response.ok) {
      throw new Error(`Network response was not ok (${response.status})`);
    }
    return response;
  });
}


// send a request that will be handled by OrderController.History based on the
// route configured with attributes (/api/order/history)
function loadOrderHistory(locationId, customerId) {
  return fetch(`api/order/history?locationId=${locationId}&customerId=${customerId}`).then(response => {
      if (!response.ok) {
        throw new Error(`Network response was not ok (${response.status})`);
      }
      return response.json();
    })
}
