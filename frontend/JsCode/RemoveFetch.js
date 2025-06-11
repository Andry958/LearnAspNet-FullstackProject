document.getElementById("RemoveBtn").onclick = function(e) {
    e.preventDefault();
    const tr = document.querySelector('#productsTable tbody tr.selected-row');
    if (!tr) {
        alert('Оберіть рядок перед видаленням!');
        return;
    }

    const tds = tr.querySelectorAll('td');
    const id = parseInt(tds[0].textContent, 10);

    fetch(`http://localhost:5201/api/products/${id}`, {
        method: 'DELETE',
    })
    .then(res => {
        if (!res.ok) throw new Error('Помилка видалення продукту');
        return res.text(); // або res.json() якщо щось повертає API
    })
    .then(() => {
        document.getElementById('message').textContent = 'Продукт видалено!';
        loadProducts(); // Оновлення таблиці
    })
    .catch(err => {
        document.getElementById('message').textContent = err.message;
    });
};