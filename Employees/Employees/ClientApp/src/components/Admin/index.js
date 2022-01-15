import React from "react";
import { FileUpload } from './FileUpload';

class Admin extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            employeePairs: [],
            test: 3
        }

    }

    ClickMe  = () =>{
        console.log("clicked")
        console.log(this.state.employeePairs)
    }

    render(){
        return <>
        <FileUpload/>
        <div onClick={this.ClickMe}>Click me</div>
        </>
    }
}

export default Admin;