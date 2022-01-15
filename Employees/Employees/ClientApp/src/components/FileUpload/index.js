import React from 'react';
import axios from 'axios';

class FileUpload extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            file: {}
        }
    }

    processFile = (e) => {
        this.setState({ file: e.target.files[0] })
    }

    uploadFile = async (e) => {
        const formData = new FormData();
        formData.append('file', this.state.file);

        try {
            const response = await axios.post('employees', formData);
            this.props.actions.registerEmployeePairs(response.data);
        } catch (ex) {
            console.log(ex);
        }
    }
    render() {
        return (
            <>
                <input className='btn btn-secondary btn-sm' type="file" onChange={this.processFile} />
                <br />
                <br />
                <input className='btn btn-primary' type="button" value='Upload' onClick={this.uploadFile} />
            </>
        );
    }
}

export default FileUpload;