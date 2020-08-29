import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom'
import './App.css'

import Register from './components/Register'
import Login from './components/Login'
import Main from './components/Main';
import Navbar from './components/Navbar';

export default function App() {
    return (
        <div className="container p-0" style={{ minWidth: '100vw' }}>
            <BrowserRouter>
                <Navbar />
                <Switch>
                    <Route path="/register" component={Register} />
                    <Route path="/login" component={Login} />
                    <Route path="/" component={Main} />
                </Switch>
            </BrowserRouter>
        </div>
    );
}