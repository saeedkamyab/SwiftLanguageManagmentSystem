window.registerEmojiHandler = (elementId, dotNetHelper) => {
    const picker = document.getElementById(elementId);
    if (!picker) {
        console.error("Emoji picker not found in DOM!");
        return;
    }

    // استفاده از یک متغیر برای جلوگیری از چندین listener
    if (!picker._hasListener) {
        picker.addEventListener('emoji-click', (event) => {
            const emoji = event.detail.unicode;
            console.log("JS detected emoji:", emoji); // چک کنید این لاگ چاپ می‌شود؟
            dotNetHelper.invokeMethodAsync('OnEmojiClick', emoji);
        });
        picker._hasListener = true;
    }
};
