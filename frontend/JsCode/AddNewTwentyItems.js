document.getElementById("AddItemsBtn").onclick = function(e){
  e.preventDefault();
  const clickedButton = e.submitter; 
  const action = clickedButton?.value;
   fetch(apiUrl + "/GetNewitems")
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
};