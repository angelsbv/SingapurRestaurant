import React, { useState } from 'react'

export default function Register() {
    const [fields, setFields] = useState({});

    const handleFormSubmit = async (e) => {
        e.preventDefault();
        try {
            const res = await fetch('/user/login', { 
                method: "POST",
                headers: {
                    'Content-Type': "application/json"
                },
                body: JSON.stringify(fields)
            });
            const json = await res.text();
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
        <div className="container" style={{ maxWidth: "550px" }}>
            <h1 className="text-center">Log in</h1>
            <form onSubmit={handleFormSubmit}>
                <div className="form-group">
                    <label htmlFor="username">Username/Email</label>
                    <input
                        onChange={handleFieldChange} 
                        type="text" 
                        id="username" 
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
