import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import Index from "./components/Index/Index";
import About from "./components/About/About";

import Layout from "./components/Layout/Layout";

const App = () => {
    return (
        <Router>
            <Routes>
                <Route
                    path="/"
                    element={
                        <Layout>
                            <Index />
                        </Layout>
                    }
                />
                <Route
                    path="/about"
                    element={
                        <Layout>
                            <About />
                        </Layout>
                    }
                />
                {/* Future routes go here, all inside <Layout> */}
                {/* <Route path="/about" element={<Layout><About /></Layout>} /> */}
            </Routes>
        </Router>
    );
};

export default App;