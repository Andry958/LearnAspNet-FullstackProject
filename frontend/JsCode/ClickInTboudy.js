document.querySelector('#productsTable tbody').addEventListener('click', (event) => {
    const tr = event.target.closest('tr');

    if (!tr) return; 


    document.querySelectorAll('#productsTable tbody tr').forEach(row => row.classList.remove('selected-row'));


    tr.classList.add('selected-row');

    const tds = tr.querySelectorAll('td');
    if (tds.length < 3) return;

    const rowData = {
        id: tds[0].textContent.trim(),
        name: tds[1].textContent.trim(),
        price: tds[2].textContent.trim()
    };

    document.getElementById('message').textContent = `Вибрано продукт: ${rowData.name}, ціна: ${rowData.price} грн. (ID: ${rowData.id})`;
});
document.querySelector('#myProductsTable tbody').addEventListener('click', (event) => {
    const tr = event.target.closest('tr');

    if (!tr) return; 

    // Видаляємо стиль з усіх рядків
    document.querySelectorAll('#myProductsTable tbody tr').forEach(row => row.classList.remove('selected-row'));

    tr.classList.add('selected-row');

    const tds = tr.querySelectorAll('td');
    if (tds.length < 3) return;

    const rowData = {
        id: tds[0].textContent.trim(),
        name: tds[1].textContent.trim(),
        price: tds[2].textContent.trim()
    };

    document.getElementById('message').textContent = `Вибрано продукт: ${rowData.name}, ціна: ${rowData.price} грн. (ID: ${rowData.id})`;
});
