import { X } from "lucide-react";
import { useState } from "react";

export default function ShoppingCart() {
    const [cartItems, setCartItems] = useState([
        {
            id: 1,
            name: "Sour Diesel - 3.5g",
            price: 35,
            quantity: 1,
            image: "https://via.placeholder.com/60",
        },
        {
            id: 2,
            name: "Gummy Edibles - 100mg",
            price: 20,
            quantity: 2,
            image: "https://via.placeholder.com/60",
        },
    ]);

    const removeItem = (id) => {
        setCartItems(cartItems.filter((item) => item.id !== id));
    };

    const total = cartItems.reduce(
        (sum, item) => sum + item.price * item.quantity,
        0
    );

    return (
        <div className="w-full max-w-md mx-auto p-4">
            <h2 className="text-lg font-semibold mb-4">Your Cart</h2>
            <div className="flex flex-col gap-4">
                {cartItems.map((item) => (
                    <div
                        key={item.id}
                        className="flex items-center justify-between border p-3 rounded-md"
                    >
                        <div className="flex items-center gap-3">
                            <img
                                src={item.image}
                                alt={item.name}
                                className="w-14 h-14 rounded object-cover"
                            />
                            <div>
                                <h3 className="font-medium text-sm">{item.name}</h3>
                                <p className="text-xs text-gray-500">
                                    ${item.price.toFixed(2)} x {item.quantity}
                                </p>
                            </div>
                        </div>
                        <button onClick={() => removeItem(item.id)} className="text-gray-400 hover:text-red-500">
                            <X size={18} />
                        </button>
                    </div>
                ))}
            </div>
            <div className="mt-6 flex justify-between items-center border-t pt-4">
                <span className="font-semibold">Total</span>
                <span className="text-green-600 font-bold">${total.toFixed(2)}</span>
            </div>
            <button className="mt-4 w-full bg-green-600 text-white py-2 rounded font-medium text-sm">
                Proceed to Checkout
            </button>
        </div>
    );
}