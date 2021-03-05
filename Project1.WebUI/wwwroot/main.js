'use strict';

// send a request that will be handled by EmailController.GetInbox based on the
// route configured with attributes (/api/inbox)
function loadUser(username, password) {
  return fetch(`api/user/login?username=${username}&$password=${password}`).then(response => {
    if (!response.ok) {
      throw new Error(`Network response was not ok (${response.status})`);
    }
    return response.json();
  });
}