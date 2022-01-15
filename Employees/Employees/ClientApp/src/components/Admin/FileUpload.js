import React, { useState } from 'react';
import axios from 'axios';

export const FileUpload = () => {
    const [file, setFile] = useState();

    const processFile = (e) => {
        setFile(e.target.files[0]);
    }

    const uploadFile = async (e) => {
        const formData = new FormData();
        formData.append('file', file);

        try{
            const res = await axios.post('employees', formData);
            console.log(res);
        } catch (ex){
            console.log(ex);
        }
    }

    return(
        <>
            <input type="file" onChange={processFile} />
            <input type="button" value='upload' onClick={uploadFile} />
        </>
    );
}