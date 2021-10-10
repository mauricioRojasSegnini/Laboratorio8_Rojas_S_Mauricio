class DataTable {
    constructor(dataOrigin, context) {
        this.dataOrigin = dataOrigin;
        this.context = context;
    }

    fillContext() {
        fetch(this.dataOrigin)
            .then(response => {
                return response.json();
            })
            .then(data => {
                let htmlContent = '<table style= "width:100%">' +
                    '<tr><th> Id </th>' +
                    '<th> Quantity </th>' +
                    '<th> Name </th>' +
                    '<th> Price </th></tr>';
                let row = '';
                for (const object of data) {
                    for (const key in object) {
                        row += `<td> ${object[key]} </td>`
                    }
                    htmlContent += `<tr> ${row} </tr>`;
                    row = '';
                }
                htmlContent += '</table>'
                console.log(htmlContent);
                this.context.innerHTML = htmlContent;
            })
            .catch(error => {
                console.log(error);
            })
    }
}