
const MessageType = {
    Error: 1,
    Success: 2,
    Warning:3
}

Object.seal(MessageType);

const MessageBox = (function () {

        let Active = false;
        let Construct = function (title, message, messageType) {
            let path = location.origin + "/Plugins/MessageBox/Assets/Images/";
            if (message == undefined) {
                throw "There Must Be a Message";
            }
            if (messageType == undefined) {
                throw "There Must Be a MessageType";
            }
            switch (messageType) {
                case MessageType.Error: {
                    path += "Error.png";
                    break;
                }
                case MessageType.Success: {
                    path += "Success.png";
                    break;
                }
                case MessageType.Warning: {
                    path += "Warning.png";
                    break;
                }

            }
            let body = document.getElementById('Message-box-container');
            body.innerHTML = `
        <style>
            .Message-box-container {
                background: rgba(29, 25, 25, 0.61);
                position: fixed;
                display: flex;
                flex-direction: column;
                top: 0;
                left: 0;
                right: 0;
                bottom: 0;
                justify-content: center;
                z-index: 2;
            }

            .Message-box {
                width: 40%;
                margin: auto;
            }

            .Message-box-header {
                background: #e3f2fd;
            }

            .Message-box {
                border: 4px solid #e3f2fd;
                border-radius: 2px;
                overflow: hidden;
            }

            @media only screen and (max-width:600px) {
                .Message-box {
                    width: 95%;
                }
            }
        </style>

        <div class="Message-box-container">
            <div class="Message-box">
                <div class="Message-box-header border-bottom">
                    <div class="row no-gutters w-100 p-1">
                        <div class="col-3"><h5 class="m-0">${title}</h5></div>
                        <div class="col-1 ml-auto d-flex justify-content-end">
                            <span class ="bg-danger d-inline-block px-2 rounded"  onclick='MessageBox.close()'>
                            <i class="fa fa-times p-0 text-light"></i></span>
                        </div>
                    </div>
                </div>
                <div class="Message-box-body bg-white">
                    <div class="row no-gutters w-100 pt-2">
                        <div class="col-2 p-1 pr-3">
                            <img src='${path}' class="img-fluid w-100" />
                        </div>
                        <div class="col-8 ml-auto p-1">
                            <p>${message}</p>
                        </div>
                    </div>
                </div>
                <div class="Message-box-footer bg-white border-top">
                    <div class="d-flex w-100 justify-content-end p-1">
                        <button onclick='MessageBox.close()' class="btn btn-info px-5 font-weight-bold border-0 text-dark" style="background:#e3f2fd;">Close</button>
                    </div>
                </div>
            </div>
        </div>`
        }
        return {
            show: function (title, message, messageType) {
                Construct(title, message, messageType);
            },
            close: function () {
                let body = document.body;
                let box = document.getElementById('Message-box-container');
                box.innerHTML = "";
            }
        }
    })();
