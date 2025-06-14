const apiUrl = 'http://localhost:5201/api/products';
const fetchitems = fetch(apiUrl)
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
document.addEventListener('DOMContentLoaded', function() {
    loadBalance();
    loadProducts();
    loadMyProducts();
});

document.getElementById("setBalanceBtn").onclick = function() {
    const num = document.getElementById('balanceInput').value;
    fetch('http://localhost:5201/api/balance', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ Value: num })
    })
    .then(res => {
        if (!res.ok) throw new Error('Помилка встановлення балансу');
        return res.text();
    })
    .then(() => loadBalance())
    .catch(() => {
        document.getElementById('message').textContent = 'Не вдалося встановити баланс.';
    });
};

