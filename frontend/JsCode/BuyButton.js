
document.getElementById('BuyItem').onclick = async function(e) {
    e.preventDefault();
    const tr = document.querySelector('#productsTable tbody tr.selected-row');
    if (!tr) {
        alert('Оберіть рядок для покупки!');
        return;
    }

    // Отримуємо дані продукту з рядка
    const tds = tr.querySelectorAll('td');
    const id = tds[0].textContent;
    const name = tds[1].textContent;
    const price = tds[2].textContent;

    try {
        // Відправляємо fetch-запит на бекенд для купівлі продукту
        const response = await fetch('http://localhost:5201/api/myproducts', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ id: Number(id), name, price: Number(price) })
        });

      if (!response.ok) {
        const msg = await response.text();
        alert('Сервер повернув помилку: ' + msg);
        document.getElementById('message').textContent = msg || 'Помилка при купівлі продукту!';
        return;
      } 

        // Отримуємо оновлений список куплених продуктів з відповіді
        loadBalance();
        const data = await response.json();

        // Оновлюємо таблицю "Мої продукти"
        const tbody = document.querySelector('#myProductsTable tbody');
        tbody.innerHTML = '';
        data.forEach(p => {
            const tr = document.createElement('tr');
            tr.innerHTML = `<td>${p.id}</td><td>${p.name}</td><td>${Number(p.price).toFixed(2)}</td>`;
            tbody.appendChild(tr);
        });

        document.getElementById('message').textContent = `Продукт "${name}" додано до ваших продуктів!`;
    } catch (err) {
        document.getElementById('message').textContent = 'Помилка зʼєднання з сервером!';
    }
};

function loadMyProducts() {
    fetch('http://localhost:5201/api/products/loadmyproducts')
        .then(res => res.json())
        .then(data => {
            const tbody = document.querySelector('#myProductsTable tbody');
            tbody.innerHTML = '';
            data.forEach(p => {
                const tr = document.createElement('tr');
                tr.innerHTML = `<td>${p.id}</td><td>${p.name}</td><td>${Number(p.price).toFixed(2)}</td>`;
                tbody.appendChild(tr);
            });
        })
        .catch(() => {
            document.getElementById('message').textContent = 'Не вдалося завантажити ваші продукти.';
        });
}