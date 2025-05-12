import Header from "../Header/Header";
import Footer from "../Footer/Footer";

const Layout = ({ children }) => {
    return (
        <div className="flex flex-col min-h-screen bg-[#0F1B17] text-white overflow-hidden">

            <div className="grid grid-cols-12 sm:hidden">
                <div className="grid col-span-3">
                    <Header />
                </div>
                <div className="grid col-span-9">
                    <main className="flex-grow px-5 py-2">{children}</main>
                </div>
            </div>

            <div className="hidden sm:block">
                <Header />

                <main className="flex-grow">{children}</main>
            </div>


            <Footer />
        </div>
    );
};

export default Layout;