$(function () {


    const setep =  $('#demo').steps({
        onChange: function (currentIndex, newIndex, stepDirection) {
            console.log('onChange', currentIndex, newIndex, stepDirection);
            // tab1
            if (stepDirection === 'backward') {
                return true;
            }
            if (currentIndex === 0) {
                if (stepDirection === 'forward') {
                    var selectedValue = $('#selectsd').val();
                    if (selectedValue) {
                        // Select foi selecionado
                        return true;
                    } else {
                        // Select não foi selecionado, impede o avanço para a próxima etapa
                        toastr.options = {
                            closeButton: true,
                            debug: false,
                            newestOnTop: false,
                            progressBar: false,
                            positionClass: 'toast-top-center',
                            preventDuplicates: false,
                            showDuration: '300',
                            hideDuration: '1000',
                            timeOut: '5000',
                            extendedTimeOut: '1000',
                            toastClass: 'toast-red toast-zindex' // Adiciona uma classe CSS personalizada com z-index maior
                        };


                        toastr.warning('Selecione uma opcao');

                        return false;
                    }
                }
                if (stepDirection === 'backward') {
                    return true;
                }
            } 
           
        },
        onFinish: function () {
            alert('complete');
        }
    });
    const steps_api = setep.data('plugin_Steps');

    $('#selectsd').on('change', function () {
    
      
        steps_api.next();

     
    });


});