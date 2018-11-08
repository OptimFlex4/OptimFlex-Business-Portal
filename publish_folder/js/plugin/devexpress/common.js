(function ($, dxbsDemo) {
    var MIDDLE_SIZE = 992;

    $(window).on("load", function () {
        initScrollPlugin();
    });

    dxbsDemo.expandedChanging = function (s, e) {
        s.CollapseAll();
    };
    dxbsDemo.onSideBarNodeClick = function (s, e) {
        var windowWidth = $(window).width();
        if (windowWidth < MIDDLE_SIZE && !$(document.body).hasClass("show-nav")) {
            $(document.body).toggleClass("show-nav", true);
            scrollToSideBarElement(e.htmlElement);
        }
        else if (windowWidth >= MIDDLE_SIZE && $(document.body).hasClass("collapse-nav")) {
            $(document.body).toggleClass("collapse-nav", false);
            scrollToSideBarElement(e.htmlElement);
        }

        if(e.node.GetNodeCount() > 0){
            var expanded = e.node.GetExpanded();
            s.CollapseAll();
            e.node.SetExpanded(!expanded);
        }
    };

    function scrollToSideBarElement(el) {
        setTimeout(function () {
            var $el = $(el);
            if (!$el.is(":mcsInSight")) {
                $("#sidebar > .sidebar-body").mCustomScrollbar("scrollTo", $el, {
                    scrollInertia: 0
                });
            }
        }, 300);
    }

    function initScrollPlugin() {
        $("#sidebar > .sidebar-body, #settingsbar").mCustomScrollbar({
            theme: "minimal-dark",
            scrollInertia: 300
        });
    }
})(jQuery, window.dxbsDemo || (window.dxbsDemo = {}));