import React from 'react';
import axios from 'axios';
import './styles.css';

class FileUpload extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            file: {},
            isFileAttached: false
        }
    }

    processFile = (e) => {
        this.setState({
            file: e.target.files[0],
            isFileAttached: true
        })
    }

    uploadFile = async (e) => {
        const formData = new FormData();
        const validationMessage = document.getElementById('validation-message');
        formData.append('file', this.state.file);

        const { setEmployeePairs, setIsFileUploaded } = this.props.actions;

        try {
            const response = await axios.post('employees', formData);

            setEmployeePairs(response.data);
            setIsFileUploaded(true);
            validationMessage.hidden = true;
        } catch (ex) {
            this.setState({ isFileAttached: false })
            const errorMessage = document.getElementById('error-message');

            if (ex.response && /: .*/.test(ex.response.data)) {
                errorMessage.innerHTML = `Error while uploading the file${ex.response.data.match(/: .*/)[0]}`;
            }

            validationMessage.hidden = false;
            setIsFileUploaded(false);
        }
    }
    render() {
        return (
            <>
                <input className='btn' type="file" onChange={this.processFile} />
                <hr />
                <input disabled={!this.state.isFileAttached} className='btn btn-primary' type="button" value='Upload' onClick={this.uploadFile} />
                <div id='validation-message' hidden>
                    <span id='error-message'>
                        Error while uploading the file.
                    </span><br />
                    Please upload a valid one in the following format: EmpID, ProjectID, DateFrom, DateTo!
                </div>
            </>
        );
    }
}

export default FileUpload;