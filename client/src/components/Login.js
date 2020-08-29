import React, { useState } from 'react'

export default function Register() {
    const [fields, setFields] = useState({});
    const [errorMsg, setErrorMsg] = useState("");

    const handleFormSubmit = async (e) => {
        e.preventDefault();
        try {
            const data = await fetch('/user/login', { 
                method: "POST",
                headers: {
                    'Content-Type': "application/json"
                },
                body: JSON.stringify(fields)
            });
            console.log(data)
            
            const res = await data.text();
            console.log(res)
            if(res === "FAIL") setErrorMsg("Papá pusiste la vaina mal coño. BOBO") 
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
            <h1 className="text-center">Log in</h1>
            <form onSubmit={handleFormSubmit}>
                {
                    errorMsg !== ""
                    && 
                    <div className="alert alert-danger" role="alert">
                        { errorMsg }
                    </div>
                }
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
