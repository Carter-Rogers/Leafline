const Footer = () => {
    return (
        <footer className="w-full py-4 px-6 bg-[#1A2A25] backdrop-blur-md shadow-inner text-sm text-center text-black/80">
            &copy; {new Date().getFullYear()} Leafline. All rights reserved.
        </footer>
    );
};

export default Footer;