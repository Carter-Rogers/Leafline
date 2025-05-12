import { useState } from "react";
import { Menu, X, ShoppingCart, Telescope} from "lucide-react";

var visible = true;


export default function Header() {
    const [reload, setReload] = useState(false);

    const Toggle = () => {
        visible = !visible;
        setReload(reload + 1);
    }

    return (
        <div>
            <div className="hidden sm:block w-full text-black">

                <h2 className="text-2xl text-black">Leafline</h2>

            </div>

            <div className="w-4/4">
                <div className="block sm:hidden text-black flex flex-col items-start bg-transparent w-full py-2 transform">
                    <div className="flex flex-col w-full items-center">
                        <div className="w-full bg-[#1A2A25] flex flex-col items-center h-[94vh] my-[-8px]"><button className="py-3 transition-all duration-150 hover:scale-110"><ShoppingCart size={48} color="#C1A15E" /></button><button className="py-3 transition-all duration-150 hover:scale-110"><Telescope size={48} color="#C1A15E"/></button></div>
                    </div>

                </div>
            </div>

           
        </div>
    );
};