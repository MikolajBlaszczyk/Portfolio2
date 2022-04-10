// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('#firstPop').popover({ content: 'i w zabudowie zagrodowej oraz mieszkania dwupoziomowe', placement: 'left', trigger: 'hover' });
$('#secondPop').popover({ content: 'budynki zamieszkania zbiorowego oraz budynki użyteczności publicznej, z wyłączeniem budynków zakładów opieki zdrowotnej 4  , a także budynki produkcyjne, magazynowo-składowe oraz usługowe, w których zatrudnia się ponad 10 osób', placement: 'left', trigger: 'hover' });
$('#thirdPop').popover({ content: 'i wolno stojące (wielostanowiskowe) oraz budynki usługowe, w których zatrudnia się do 10 osób', placement: 'left', trigger: 'hover' });
$('#fourthPop').popover({ content: 'niezależnie od ich przeznaczenia schody do kondygnacji podziemnej, pomieszczeń technicznych i poddaszy nieużytkowych', placement: 'left', trigger:'hover'})

$('#rangeInputHeight').on('input', function () {
    Change(1);
    $('#heightChange').html('Wysokość: '+$(this).val().replace('.',','));
});

$('#rangeInputWidth').on('input', function () {
    Change(2);
    $('#widthChange').html('Szerokość: '+$(this).val().replace('.',','));
});

$('#rangeInputDepth').on('input', function () {
    Change(3);
    $('#depthChange').html('Głębokość: '+$(this).val().replace('.',','));
});

//TO DO
//function adjustParams(input,depth,height) {
//    let pattern = 0.0;
//    pattern = depth + 2 * height;
//    if (input == 1) {
//        if (pattern > 0.65 || 0.6 < pattern) {
//            depth = 0.65 - 2 * height;
//        }
//    }
//    else if (input == 3) {
//        if (pattern > 0.65 || 0.6 > pattern) {
//            height = (0.65 - depth) / 2;
//        }
//    }
//    $('#rangeInputHeight').val(height);
//    $('#heightChange').html('Wysokość: ' + height.replace('.', ','));
//    $('#rangeInputDepth').val(depth);
//    $('#depthChange').html('Głębokość: ' + depth.replace('.', ','))
//}

function Change(input) {
    //let heigth = 0.0;
    //let depth = 0.0;
    //height = $('#rangeInputHeight').val();
    //depth = $('#rangeInputHeight').val();
    $('#result').slideUp(400);

    //if (input == 1) {
    //    adjustParams(input, depth, height);
    //}
    //else if (input == 3) {
    //    adjustParams(input, depth, height);
    //}
}