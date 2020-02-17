function initUploader(element, storage, loader, handler) {
    
    element.change(function (e) {
        let data = new FormData();
        var supportedext = ['.jpg', '.png'];
        let check = false;
        for (let i = 0 ; i < $(this).get(0).files.length ; i++) {
            let ele = $(this).get(0).files[i].name;
            supportedext.forEach(function (_element) {
                if (ele.indexOf(_element) != -1) {
                    check = true;
                }
            })
            if (check) {
                data.append("profile", $(this).get(0).files[0]);
                $.ajax({
                    url: handler,
                    data: data,
                    type: 'POST',
                    contentType: false, // NEEDED, DON'T OMIT THIS (requires jQuery 1.6+)
                    processData: false, // NEEDED, DON'T OMIT THIS
                    success: function (data) {
                        if (storage != null || storage!= undefined) {
                            storage.val(data);
                        }
                        if (loader != null || loader != undefined) {
                            loader.attr("src","../../../Images/Profile/"+data)
                        }
                    }
                });
            } else {
                alert("Not a suppoted file");
            }
        }
    })
}