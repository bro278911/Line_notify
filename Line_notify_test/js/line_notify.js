
$("#notify_click").on('click', function () {
    sendMessage("測試訊息");
});
function sendMessage(message) {
    //var token = 'uhPkQGluQPAYDOcdUefWtS386G4JolscRJiEKZVzYRf';
    var option = {
        method: 'post',
        headers: { Authorization: 'Bearer ' + uhPkQGluQPAYDOcdUefWtS386G4JolscRJiEKZVzYRf },
        payload: {
            // 這邊單純傳訊息，如果想要加上傳貼圖或圖片，就看參數自行新增
            message: message
        }
    };
    UrlFetchApp.fetch('https://notify-api.line.me/api/notify', option);
}