import React, { useState } from 'react'

export default function Register() {
    const [fields, setFields] = useState({});

    const handleFormSubmit = async (e) => {
        e.preventDefault();
        try {
            const res = await fetch('/user/register', { 
                method: "POST",
                headers: {
                    'Content-Type': "application/json"
                },
                body: JSON.stringify(fields)
            });
            const json = await res.json();
            console.log(json);
        } catch (error) {
            console.error(error);
        }
    }

    const handleFieldChange = (e) => {
        const { target } = e
        setFields({ ...fields, [target.id]: target.value })
    }

    return (
        <div className="container d-flex flex-column justify-content-center" style={{ maxWidth: "550px", minHeight: "90vh" }}>
            <h1 className="text-center">Sign up</h1>
            <form onSubmit={handleFormSubmit}>
                <div className="form-group">
                    <label htmlFor="username">Username</label>
                    <input 
                        onChange={handleFieldChange} 
                        type="text" 
                        id="username" 
                        autoComplete="off"
                        className="form-control"
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="email">Email</label>
                    <input 
                        onChange={handleFieldChange} 
                        type="text" 
                        id="email" 
                        autoComplete="off"
                        className="form-control" 
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="password">Password</label>
                    <input 
                        onChange={handleFieldChange} 
                        type="password" 
                        id="password"
                        className="form-control" 
                    />
                </div>
                <div className="form-group">
                    <button className="btn btn-primary btn-block" type="submit">Submit</button>
                </div>
            </form>
        </div>
    )
}
