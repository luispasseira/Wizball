var fileUpload = document.getElementById("attachmentInp");
var customFileUpload = document.getElementById("btnCustomFileUpload");
var uploadStatus = document.getElementById("upload-status");
var SubBtn = document.getElementById("Send");

customFileUpload.addEventListener("click", function () {

    fileUpload.click();

}); 

fileUpload.addEventListener("change", function () {
    var TotalSize = 0;

    for (var i = 0; i < this.files.length; i++) {
        TotalSize += this.files[i].size;
    }    

    if (TotalSize > 20971520) {
        uploadStatus.innerHTML = "The total size of the files must NOT exceed 20MB in size";
        SubBtn.disabled = true;
        return;
    } else {
        uploadStatus.innerHTML = "You have selected " + this.files.length + " files to upload.";
        SubBtn.disabled = false;
    }

});