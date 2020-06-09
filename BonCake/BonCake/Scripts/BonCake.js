// 下拉 模块
$(function () {
    $('#collapseFour').collapse({
        toggle: false
    })
});
$(function () {
    $('#collapseTwo').collapse('hide')
});
$(function () {
    $('#collapseThree').collapse('hide')
});
$(function () {
    $('#collapseOne').collapse('hide')
});
$(function () {
    var sdBoxW = $('.moveBox').css('width');
    sdBoxW = parseInt(sdBoxW);//移动层的宽度
    var magBoxW = $('.magBox').css('width');
    magBoxW = parseInt(magBoxW);//图片放大层的宽度
    var normalBoxW = $('.normalBox').css('width');
    normalBoxW = parseInt(normalBoxW);//事件绑定层的宽度
    var num = 0;//存放下标
    //找出放大图片的比例(核心)
    var scale = magBoxW / sdBoxW;
    //移入normalBox盒子
    $('.normalBox').hover(function () {
        $('.moveBox').css('display', 'block');
        $('.magBox').css('display', 'block');
    }, function () {
        $('.moveBox').css('display', 'none');
        $('.magBox').css('display', 'none');
    });
    //3、移入leftBox层
    $('.leftBox').mouseover(function () {
        //给放大的图片和图片层设置宽度；
        $('.magBox ul li img').css('width', scale * normalBoxW + 'px');
        $('.magBox ul li').css({ 'width': scale * normalBoxW + 'px', 'height': scale * normalBoxW + 'px' })
    });
    //1、移入缩小图关联
    $('.botBox ul li').attr('index', function (i, e) {
        return i;
    });
    $('.botBox ul li').mouseover(function () {
        if ($(this).attr('class') == 'bord') {
            return;//跳过第一个
        } else {
            $(this).attr('class', 'bord').siblings().removeAttr('class');
            var index = $(this).attr('index');
            //联动normal和magBox中的图片
            $('.normalBox .w').eq(index).attr('id', 'n').siblings().removeAttr('id');
            $('.magBox ul li').eq(index).attr('class', 'm').siblings().removeAttr('class');
            num = index;
        }
    });
    //2、鼠标在移动层移动
    $('.normalBox').mousemove(function (e) {
        var offset = $(this).offset();
        var X = e.pageX - offset.left - $('.moveBox').width() / 2;
        var Y = e.pageY - offset.top - $('.moveBox').height() / 2;
        if (X <= 0) {
            X = 0;
        } else if (X > $(this).width() - $('.moveBox').width()) {
            X = $(this).width() - $('.moveBox').width();
        }
        if (Y <= 0) {
            Y = 0;
        } else if (Y > $(this).height() - $('.moveBox').height()) {
            Y = $(this).height() - $('.moveBox').height();
        }
        $('.moveBox').css('left', X + 'px');
        $('.moveBox').css('top', Y + 'px');
        $('.magBox ul li').eq(num).css('left', -X * scale + 'px');
        $('.magBox ul li').eq(num).css('top', -Y * scale + 'px');
    });

    for (var i = 0; i < 5; i++) {
        $(".content_down-icon").click(function () {
            $(".content_down-icon2").css("padding", "1010px 0px 0px 0px");
            $(".content_down-icon").click(function () {
                $(".content_down-icon2").css("padding", "0px 0px 0px 0px");
            })
        })
    }

})