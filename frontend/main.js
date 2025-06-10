 const apiUrl = 'http://localhost:5201/api/products';
const fetchitems = fetch(apiUrl)

  // Завантажити список продуктів і показати у таблиці
  function loadProducts() {
    fetch(apiUrl)
      .then(res => res.json())
      .then(data => {
        const tbody = document.querySelector('#productsTable tbody');
        tbody.innerHTML = '';
        data.forEach(p => {
          const tr = document.createElement('tr');
          tr.innerHTML = `<td>${p.id}</td><td>${p.name}</td><td>${p.price.toFixed(2)}</td>`;
          tbody.appendChild(tr);
        });
      })
      .catch(() => {
        document.getElementById('message').textContent = 'Не вдалося завантажити продукти.';
      });
  }

  // Обробник форми додавання
  

document.getElementById('addProductForm').addEventListener('submit', function(e) {
  e.preventDefault();

  const clickedButton = e.submitter; // ← яка кнопка була натиснута
  const action = clickedButton?.value;

  const name = document.getElementById('productName').value.trim();
  const price = parseFloat(document.getElementById('productPrice').value);

  if (!name || isNaN(price)) {
    alert('Введіть правильні дані');
    return;
  }

  fetch('http://localhost:5201/api/products', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ name, price }),
  })
  .then(res => {
    if (!res.ok) throw new Error('Помилка додавання продукту');
    return res.json();
  })
  .then(() => {
    document.getElementById('message').textContent = 'Продукт додано!';
    this.reset();
    loadProducts();
  })
  .catch(err => {
    document.getElementById('message').textContent = err.message;
  });
});
function a(){
     const tr = event.target.closest('tr');
    if (!tr) return;
    
    return tr
    // Зняти підсвітку з інших
   
}
  // Делегуємо подію кліку на tbody
  document.querySelector('#productsTable tbody').addEventListener('click', (event) => {
      const tr=  a()
        document.querySelectorAll('#productsTable tbody tr').forEach(row =>
      row.classList.remove('selected-row'));

    tr.classList.add('selected-row');

    const tds = tr.querySelectorAll('td');
    const rowData = {
      id: tds[0].textContent,
      name: tds[1].textContent,
      price: tds[2].textContent,
    };
    document.getElementById('message').textContent = 
      `Вибрано продукт: ${rowData.name}, ціна: ${rowData.price} грн. (ID: ${rowData.id})`;
  });

  // Початкове завантаження
  loadProducts();

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

    fetch(`http://localhost:5201/api/products/${newName}${newPrice}`, {
        method: 'OPTIONS',
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
}
