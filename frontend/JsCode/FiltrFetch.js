let selectElement = document.getElementById("filtrBy");

selectElement.addEventListener("change", function() {
    fetch(apiUrl+ `/Filtr`, {
        method: "POST",
    headers: {
        "Content-Type": "application/json"
    },
    body: JSON.stringify({ value: selectElement.value })
    })
    .then(response => response.json())
    .then(data => {
        const tbody = document.querySelector('#productsTable tbody');
        tbody.innerHTML = '';
        data.forEach(p => {
          const tr = document.createElement('tr');
          tr.innerHTML = `<td>${p.id}</td><td>${p.name}</td><td>${p.price.toFixed(2)}</td>`;
          tbody.appendChild(tr);
        });
      })
    .catch(error => console.error("Помилка:", error));
});

