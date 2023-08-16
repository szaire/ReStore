import React, { useState } from "react";

function App() {
   const [products, setProducts] = useState([
      { name: "product1", price: 100.0 },
      { name: "product2", price: 200.0 },
      { name: "product3", price: 300.0 },
   ]);

   function addProduct() {
      setProducts((prevState) => [
         ...prevState,
         {
            name: "product" + prevState.length,
            price: prevState.length * 100,
         },
      ]);
   }

   return (
      <div className="app">
         <h1>Re-Store</h1>

         <button onClick={addProduct}>Add Product</button>

         <ul>
            {products.map((product, index) => (
               <li key={index}>
                  <a href=""></a>
                  Product {index} - Name: {product.name} - R$ {product.price}
               </li>
            ))}
         </ul>
      </div>
   );
}

export default App;
