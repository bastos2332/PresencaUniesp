function CopiarLinkTurma(btn) {
    try {
        var content = $(btn).parent().parent().find(".textArea-link-turma");
        content.select();
        document.execCommand('copy');
        setTimeout(function () {
            $(btn).html("<i class='fa fa-check'></i> Link Copiado!");
        }, 1500)

    } catch (err) {
        console.log(err);
    }
}