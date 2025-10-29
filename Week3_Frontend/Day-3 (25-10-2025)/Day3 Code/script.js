// JavaScript for Day 3 - DOM Manipulation, Event Handling, Fetch API

// 1. Handle Form Submission
document.getElementById("studentForm").addEventListener("submit", function(event) {
  event.preventDefault(); // Prevent form reload

  // Get values
  const name = document.getElementById("name").value.trim();
  const email = document.getElementById("email").value.trim();
  const course = document.getElementById("course").value;

  // Validate inputs
  if (!name || !email || !course) {
    alert("Please fill all fields.");
    return;
  }

  // Add to table
  const table = document.getElementById("studentTable").getElementsByTagName("tbody")[0];
  const newRow = table.insertRow();

  newRow.insertCell(0).textContent = name;
  newRow.insertCell(1).textContent = email;
  newRow.insertCell(2).textContent = course;

  // Confirmation
  alert("Student registered successfully!");

  // Clear form
  document.getElementById("studentForm").reset();
});

// 2. Change Heading Color
document.getElementById("colorBtn").addEventListener("click", function() {
  const heading = document.getElementById("title");
  heading.style.color = heading.style.color === "orange" ? "darkblue" : "orange";
});

// 3. Fetch Sample Data from Public API
document.getElementById("fetchBtn").addEventListener("click", function() {
  const apiDiv = document.getElementById("apiData");
  apiDiv.innerHTML = "<p>Loading sample data...</p>";

  fetch("https://jsonplaceholder.typicode.com/users")
    .then(response => response.json())
    .then(data => {
      let output = "<h4>Sample User Data (Fetched from API)</h4>";
      output += "<ul class='list-group'>";
      data.slice(0, 5).forEach(user => {
        output += `<li class='list-group-item'><strong>${user.name}</strong> — ${user.email}</li>`;
      });
      output += "</ul>";
      apiDiv.innerHTML = output;
    })
    .catch(error => {
      console.error("Error:", error);
      apiDiv.innerHTML = "<p style='color:red;'>Failed to load data.</p>";
    });
});
