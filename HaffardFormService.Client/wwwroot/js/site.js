// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.getElementById("loadFields").addEventListener("click", async () => {
    const industryType = document.getElementById("industryType").value;
    const formContainer = document.getElementById("formContainer");
    const submitButton = document.getElementById("submitButton");

    if (!industryType) {
        formContainer.innerHTML = `<p style="color: red;">Please select an industry.</p>`;
        submitButton.style.display = "none"; // Hide submit
        return;
    }

    try {
        const response = await fetch(`/Home/GetFields?industry=${industryType}`);
        const data = await response.json();

        if (!data.success) {
            formContainer.innerHTML = `<p style="color: red;">${data.message}</p>`;
            submitButton.style.display = "none"; 
            return;
        }

        formContainer.innerHTML = ""; // Clear existing form
        data.fields.forEach(field => {
            const inputDiv = document.createElement("div");
            inputDiv.className = "form-group";
            inputDiv.innerHTML = `
                <label>${field}</label>
                <input type="text" class="form-control" placeholder="Enter ${field}">
            `;
            formContainer.appendChild(inputDiv);
        });
        submitButton.style.display = "block"; // Show submit button
    } catch (error) {
        formContainer.innerHTML = `<p style="color: red;">An error occurred. Please try again later.</p>`;
        submitButton.style.display = "none";
    }
});


