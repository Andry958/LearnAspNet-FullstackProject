function loadBalance() {
    fetch('http://localhost:5201/api/products/loadmybalance')
      .then(res => res.json())
      .then(data => {
        const Balance = document.getElementById("BalanceP");
        Balance.textContent = `${data}`;
      })
      .catch(() => {
        document.getElementById('message').textContent = 'Не вдалося завантажити продукти.';
      });
}