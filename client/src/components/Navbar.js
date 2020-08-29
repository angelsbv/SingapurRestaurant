import React from 'react'
import { Link } from 'react-router-dom'

export default function Navbar() {
    return (
        <nav className="navbar navbar-expand-lg navbar-light bg-primary" style={{ minHeight: "10vh" }}>
            <span className="navbar-brand text-white">Singapur Restaurant</span>
            <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span className="navbar-toggler-icon"></span>
            </button>
            <div className="collapse navbar-collapse" id="navbarSupportedContent">
                <ul className="navbar-nav mr-auto">
                    <li className="nav-item">
                        <Link to="/" className="nav-link text-white">Home</Link>
                    </li>
                    <li className="nav-item">
                        <Link to="/login" className="nav-link text-white">Log in</Link>
                    </li>
                    <li className="nav-item">
                        <Link to="/register" className="nav-link text-white">Sign in</Link>
                    </li>
                </ul>
            </div>
        </nav>
    )
}
