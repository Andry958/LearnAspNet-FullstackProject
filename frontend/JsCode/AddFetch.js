document.getElementById('addProductForm').onsubmit = async function(e) {
  e.preventDefault();
  const name = document.getElementById('productName').value;
  const price = parseFloat(document.getElementById('productPrice').value);
  const editId = this.dataset.editId;

  if (editId) {
    await fetch(`http://localhost:5201/api/products/${editId}`, {
      method: 'PUT',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ name, price })
    });
    delete this.dataset.editId;
    document.getElementById('add').textContent = 'Додати';
  } else {
    await fetch('http://localhost:5201/api/products', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ name, price })
    });
  }

  this.reset();
  loadProducts();
};