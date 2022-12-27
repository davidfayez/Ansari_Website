var common = (function () {
    function renderModalView(modalId, modaldialogId, bodyHtml, isMobilePreview) {
        var mopPrev = isMobilePreview === true ? 'mob-preview' : '';
        var htmlContainer = `<div class="modal fade ${mopPrev}" tabindex="-1" id="${modalId}" aria-labelledby="exampleModalLabel" aria-hidden="true">
<div  class="modal-dialog modal-small-big modal-dialog-centered"  style="max-width: 600px;" id="${modaldialogId}">
${bodyHtml}
</div>
</div>`;
        $('#ModalContainerRenderSection').html('');
        $('#ModalContainerRenderSection').append(htmlContainer);
        $('#' + modalId).modal('show');



    }



    var _getPartialViewModal = async function (url, data, modalId, modaldialogId, isMobilePreview = false) {
        const returnResult = await $.ajax({
            type: "GET",
            url: url,
            data: data,
            success: function (result) {
                renderModalView(modalId, modaldialogId, result, isMobilePreview);
            },
        });
        return returnResult;
    };

    var _renderPartialView = async function (url, data, contanierId) {
        const returnResult = await $.ajax({
            type: "GET",
            url: url,
            data: data,
            success: function (result) {
                $('#' + contanierId).empty();
                $('#' + contanierId).append(result);
            },
        });
        return returnResult;
    };

    return {
        getPartialViewModal: _getPartialViewModal,
        renderPartialView: _renderPartialView,
    };

})();

