document.getElementById("ChangeBtn").onclick = function(e) {
    e.preventDefault();
    const tr = document.querySelector('#productsTable tbody tr.selected-row');
    if (!tr) {
        alert('Оберіть рядок перед видаленням!');
        return;
    }

    const tds = tr.querySelectorAll('td');
    const id = parseInt(tds[0].textContent, 10);

    const rowData = {
      id: tds[0].textContent,
      name: tds[1].textContent,
      price: tds[2].textContent,
    };
    const newName = prompt("Введіть нове імя:");
    const newPrice = prompt("Введіть нову ціну:");

    fetch(`http://localhost:5201/api/products/${id}/${newName}/${newPrice}`, {
        method: 'PATCH',

    })
    .then(res => {
        if (!res.ok) throw new Error('Помилка видалення продукту');
        return res.text(); 
    })
    .then(() => {
        document.getElementById('message').textContent = 'Продукт змінено!';
        loadProducts(); 
    })
    .catch(err => {
        document.getElementById('message').textContent = err.message;
    });
}