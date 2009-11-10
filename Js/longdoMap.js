// From http://www.quirksmode.org/js/detect.html

var detect = navigator.userAgent.toLowerCase();
var OS, browser, version, total, thestring;

if (checkIt('konqueror')) {
    browser = "Konqueror";
    OS = "Linux";
}
else if (checkIt('safari')) browser = "Safari"
else if (checkIt('omniweb')) browser = "OmniWeb"
else if (checkIt('opera')) browser = "Opera"
else if (checkIt('webtv')) browser = "WebTV";
else if (checkIt('icab')) browser = "iCab"
else if (checkIt('msie')) browser = "IE"
else if (!checkIt('compatible')) {
    browser = "Netscape"
    version = detect.charAt(8);
}
else browser = "An unknown browser";

if (!version) version = detect.charAt(place + thestring.length);

if (!OS) {
    if (checkIt('linux')) OS = "Linux";
    else if (checkIt('x11')) OS = "Unix";
    else if (checkIt('mac')) OS = "Mac"
    else if (checkIt('win')) OS = "Windows"
    else OS = "an unknown operating system";
}

function checkIt(string) {
    place = detect.indexOf(string) + 1;
    thestring = string;
    return place;
}
/* This notice must be untouched at all times.

wz_jsgraphics.js    v. 2.36
The latest version is available at
http://www.walterzorn.com
or http://www.devira.com
or http://www.walterzorn.de

Copyright (c) 2002-2004 Walter Zorn. All rights reserved.
Created 3. 11. 2002 by Walter Zorn (Web: http://www.walterzorn.com )
Last modified: 21. 6. 2006

Performance optimizations for Internet Explorer
by Thomas Frank and John Holdsworth.
fillPolygon method implemented by Matthieu Haller.

High Performance JavaScript Graphics Library.
Provides methods
- to draw lines, rectangles, ellipses, polygons
with specifiable line thickness,
- to fill rectangles and ellipses
- to draw text.
NOTE: Operations, functions and branching have rather been optimized
to efficiency and speed than to shortness of source code.

LICENSE: LGPL

This library is free software; you can redistribute it and/or
modify it under the terms of the GNU Lesser General Public
License (LGPL) as published by the Free Software Foundation; either
version 2.1 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public
License along with this library; if not, write to the Free Software
Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA,
or see http://www.gnu.org/copyleft/lesser.html
*/


var jg_ihtm, jg_ie, jg_fast, jg_dom, jg_moz,
jg_n4 = (document.layers && typeof document.classes != "undefined");


function chkDHTM(x, i) {
    x = document.body || null;
    jg_ie = x && typeof x.insertAdjacentHTML != "undefined";
    jg_dom = (x && !jg_ie &&
		typeof x.appendChild != "undefined" &&
		typeof document.createRange != "undefined" &&
		typeof (i = document.createRange()).setStartBefore != "undefined" &&
		typeof i.createContextualFragment != "undefined");
    jg_ihtm = !jg_ie && !jg_dom && x && typeof x.innerHTML != "undefined";
    jg_fast = jg_ie && document.all && !window.opera;
    jg_moz = jg_dom && typeof x.style.MozOpacity != "undefined";
}


function pntDoc() {
    this.wnd.document.write(jg_fast ? this.htmRpc() : this.htm);
    this.htm = '';
}


function pntCnvDom() {
    var x = this.wnd.document.createRange();
    x.setStartBefore(this.cnv);
    x = x.createContextualFragment(jg_fast ? this.htmRpc() : this.htm);
    if (this.cnv) this.cnv.appendChild(x);
    this.htm = '';
}


function pntCnvIe() {
    if (this.cnv) this.cnv.insertAdjacentHTML("BeforeEnd", jg_fast ? this.htmRpc() : this.htm);
    this.htm = '';
}


function pntCnvIhtm() {
    if (this.cnv) this.cnv.innerHTML += this.htm;
    this.htm = '';
}


function pntCnv() {
    this.htm = '';
}


function mkDiv(x, y, w, h) {
    this.htm += '<div style="position:absolute;' +
		'left:' + x + 'px;' +
		'top:' + y + 'px;' +
		'width:' + w + 'px;' +
		'height:' + h + 'px;' +
		'clip:rect(0,' + w + 'px,' + h + 'px,0);' +
		'background-color:' + this.color +
		(!jg_moz ? ';overflow:hidden' : '') +
		';"><\/div>';
}


function mkDivIe(x, y, w, h) {
    this.htm += '%%' + this.color + ';' + x + ';' + y + ';' + w + ';' + h + ';';
}


function mkDivPrt(x, y, w, h) {
    this.htm += '<div style="position:absolute;' +
		'border-left:' + w + 'px solid ' + this.color + ';' +
		'left:' + x + 'px;' +
		'top:' + y + 'px;' +
		'width:0px;' +
		'height:' + h + 'px;' +
		'clip:rect(0,' + w + 'px,' + h + 'px,0);' +
		'background-color:' + this.color +
		(!jg_moz ? ';overflow:hidden' : '') +
		';"><\/div>';
}


function mkLyr(x, y, w, h) {
    this.htm += '<layer ' +
		'left="' + x + '" ' +
		'top="' + y + '" ' +
		'width="' + w + '" ' +
		'height="' + h + '" ' +
		'bgcolor="' + this.color + '"><\/layer>\n';
}


var regex = /%%([^;]+);([^;]+);([^;]+);([^;]+);([^;]+);/g;
function htmRpc() {
    return this.htm.replace(
		regex,
		'<div style="overflow:hidden;position:absolute;background-color:' +
		'$1;left:$2;top:$3;width:$4;height:$5"></div>\n');
}


function htmPrtRpc() {
    return this.htm.replace(
		regex,
		'<div style="overflow:hidden;position:absolute;background-color:' +
		'$1;left:$2;top:$3;width:$4;height:$5;border-left:$4px solid $1"></div>\n');
}


function mkLin(x1, y1, x2, y2) {
    if (x1 > x2) {
        var _x2 = x2;
        var _y2 = y2;
        x2 = x1;
        y2 = y1;
        x1 = _x2;
        y1 = _y2;
    }
    var dx = x2 - x1, dy = Math.abs(y2 - y1),
	x = x1, y = y1,
	yIncr = (y1 > y2) ? -1 : 1;

    if (dx >= dy) {
        var pr = dy << 1,
		pru = pr - (dx << 1),
		p = pr - dx,
		ox = x;
        while ((dx--) > 0) {
            ++x;
            if (p > 0) {
                this.mkDiv(ox, y, x - ox, 1);
                y += yIncr;
                p += pru;
                ox = x;
            }
            else p += pr;
        }
        this.mkDiv(ox, y, x2 - ox + 1, 1);
    }

    else {
        var pr = dx << 1,
		pru = pr - (dy << 1),
		p = pr - dy,
		oy = y;
        if (y2 <= y1) {
            while ((dy--) > 0) {
                if (p > 0) {
                    this.mkDiv(x++, y, 1, oy - y + 1);
                    y += yIncr;
                    p += pru;
                    oy = y;
                }
                else {
                    y += yIncr;
                    p += pr;
                }
            }
            this.mkDiv(x2, y2, 1, oy - y2 + 1);
        }
        else {
            while ((dy--) > 0) {
                y += yIncr;
                if (p > 0) {
                    this.mkDiv(x++, oy, 1, y - oy);
                    p += pru;
                    oy = y;
                }
                else p += pr;
            }
            this.mkDiv(x2, oy, 1, y2 - oy + 1);
        }
    }
}


function mkLin2D(x1, y1, x2, y2) {
    if (x1 > x2) {
        var _x2 = x2;
        var _y2 = y2;
        x2 = x1;
        y2 = y1;
        x1 = _x2;
        y1 = _y2;
    }
    var dx = x2 - x1, dy = Math.abs(y2 - y1),
	x = x1, y = y1,
	yIncr = (y1 > y2) ? -1 : 1;

    var s = this.stroke;
    if (dx >= dy) {
        if (dx > 0 && s - 3 > 0) {
            var _s = (s * dx * Math.sqrt(1 + dy * dy / (dx * dx)) - dx - (s >> 1) * dy) / dx;
            _s = (!(s - 4) ? Math.ceil(_s) : Math.round(_s)) + 1;
        }
        else var _s = s;
        var ad = Math.ceil(s / 2);

        var pr = dy << 1,
		pru = pr - (dx << 1),
		p = pr - dx,
		ox = x;
        while ((dx--) > 0) {
            ++x;
            if (p > 0) {
                this.mkDiv(ox, y, x - ox + ad, _s);
                y += yIncr;
                p += pru;
                ox = x;
            }
            else p += pr;
        }
        this.mkDiv(ox, y, x2 - ox + ad + 1, _s);
    }

    else {
        if (s - 3 > 0) {
            var _s = (s * dy * Math.sqrt(1 + dx * dx / (dy * dy)) - (s >> 1) * dx - dy) / dy;
            _s = (!(s - 4) ? Math.ceil(_s) : Math.round(_s)) + 1;
        }
        else var _s = s;
        var ad = Math.round(s / 2);

        var pr = dx << 1,
		pru = pr - (dy << 1),
		p = pr - dy,
		oy = y;
        if (y2 <= y1) {
            ++ad;
            while ((dy--) > 0) {
                if (p > 0) {
                    this.mkDiv(x++, y, _s, oy - y + ad);
                    y += yIncr;
                    p += pru;
                    oy = y;
                }
                else {
                    y += yIncr;
                    p += pr;
                }
            }
            this.mkDiv(x2, y2, _s, oy - y2 + ad);
        }
        else {
            while ((dy--) > 0) {
                y += yIncr;
                if (p > 0) {
                    this.mkDiv(x++, oy, _s, y - oy + ad);
                    p += pru;
                    oy = y;
                }
                else p += pr;
            }
            this.mkDiv(x2, oy, _s, y2 - oy + ad + 1);
        }
    }
}


function mkLinDott(x1, y1, x2, y2) {
    if (x1 > x2) {
        var _x2 = x2;
        var _y2 = y2;
        x2 = x1;
        y2 = y1;
        x1 = _x2;
        y1 = _y2;
    }
    var dx = x2 - x1, dy = Math.abs(y2 - y1),
	x = x1, y = y1,
	yIncr = (y1 > y2) ? -1 : 1,
	drw = true;
    if (dx >= dy) {
        var pr = dy << 1,
		pru = pr - (dx << 1),
		p = pr - dx;
        while ((dx--) > 0) {
            if (drw) this.mkDiv(x, y, 1, 1);
            drw = !drw;
            if (p > 0) {
                y += yIncr;
                p += pru;
            }
            else p += pr;
            ++x;
        }
        if (drw) this.mkDiv(x, y, 1, 1);
    }

    else {
        var pr = dx << 1,
		pru = pr - (dy << 1),
		p = pr - dy;
        while ((dy--) > 0) {
            if (drw) this.mkDiv(x, y, 1, 1);
            drw = !drw;
            y += yIncr;
            if (p > 0) {
                ++x;
                p += pru;
            }
            else p += pr;
        }
        if (drw) this.mkDiv(x, y, 1, 1);
    }
}


function mkOv(left, top, width, height) {
    var a = width >> 1, b = height >> 1,
	wod = width & 1, hod = (height & 1) + 1,
	cx = left + a, cy = top + b,
	x = 0, y = b,
	ox = 0, oy = b,
	aa = (a * a) << 1, bb = (b * b) << 1,
	st = (aa >> 1) * (1 - (b << 1)) + bb,
	tt = (bb >> 1) - aa * ((b << 1) - 1),
	w, h;
    while (y > 0) {
        if (st < 0) {
            st += bb * ((x << 1) + 3);
            tt += (bb << 1) * (++x);
        }
        else if (tt < 0) {
            st += bb * ((x << 1) + 3) - (aa << 1) * (y - 1);
            tt += (bb << 1) * (++x) - aa * (((y--) << 1) - 3);
            w = x - ox;
            h = oy - y;
            if (w & 2 && h & 2) {
                this.mkOvQds(cx, cy, -x + 2, ox + wod, -oy, oy - 1 + hod, 1, 1);
                this.mkOvQds(cx, cy, -x + 1, x - 1 + wod, -y - 1, y + hod, 1, 1);
            }
            else this.mkOvQds(cx, cy, -x + 1, ox + wod, -oy, oy - h + hod, w, h);
            ox = x;
            oy = y;
        }
        else {
            tt -= aa * ((y << 1) - 3);
            st -= (aa << 1) * (--y);
        }
    }
    this.mkDiv(cx - a, cy - oy, a - ox + 1, (oy << 1) + hod);
    this.mkDiv(cx + ox + wod, cy - oy, a - ox + 1, (oy << 1) + hod);
}


function mkOv2D(left, top, width, height) {
    var s = this.stroke;
    width += s - 1;
    height += s - 1;
    var a = width >> 1, b = height >> 1,
	wod = width & 1, hod = (height & 1) + 1,
	cx = left + a, cy = top + b,
	x = 0, y = b,
	aa = (a * a) << 1, bb = (b * b) << 1,
	st = (aa >> 1) * (1 - (b << 1)) + bb,
	tt = (bb >> 1) - aa * ((b << 1) - 1);

    if (s - 4 < 0 && (!(s - 2) || width - 51 > 0 && height - 51 > 0)) {
        var ox = 0, oy = b,
		w, h,
		pxl, pxr, pxt, pxb, pxw;
        while (y > 0) {
            if (st < 0) {
                st += bb * ((x << 1) + 3);
                tt += (bb << 1) * (++x);
            }
            else if (tt < 0) {
                st += bb * ((x << 1) + 3) - (aa << 1) * (y - 1);
                tt += (bb << 1) * (++x) - aa * (((y--) << 1) - 3);
                w = x - ox;
                h = oy - y;

                if (w - 1) {
                    pxw = w + 1 + (s & 1);
                    h = s;
                }
                else if (h - 1) {
                    pxw = s;
                    h += 1 + (s & 1);
                }
                else pxw = h = s;
                this.mkOvQds(cx, cy, -x + 1, ox - pxw + w + wod, -oy, -h + oy + hod, pxw, h);
                ox = x;
                oy = y;
            }
            else {
                tt -= aa * ((y << 1) - 3);
                st -= (aa << 1) * (--y);
            }
        }
        this.mkDiv(cx - a, cy - oy, s, (oy << 1) + hod);
        this.mkDiv(cx + a + wod - s + 1, cy - oy, s, (oy << 1) + hod);
    }

    else {
        var _a = (width - ((s - 1) << 1)) >> 1,
		_b = (height - ((s - 1) << 1)) >> 1,
		_x = 0, _y = _b,
		_aa = (_a * _a) << 1, _bb = (_b * _b) << 1,
		_st = (_aa >> 1) * (1 - (_b << 1)) + _bb,
		_tt = (_bb >> 1) - _aa * ((_b << 1) - 1),

		pxl = new Array(),
		pxt = new Array(),
		_pxb = new Array();
        pxl[0] = 0;
        pxt[0] = b;
        _pxb[0] = _b - 1;
        while (y > 0) {
            if (st < 0) {
                st += bb * ((x << 1) + 3);
                tt += (bb << 1) * (++x);
                pxl[pxl.length] = x;
                pxt[pxt.length] = y;
            }
            else if (tt < 0) {
                st += bb * ((x << 1) + 3) - (aa << 1) * (y - 1);
                tt += (bb << 1) * (++x) - aa * (((y--) << 1) - 3);
                pxl[pxl.length] = x;
                pxt[pxt.length] = y;
            }
            else {
                tt -= aa * ((y << 1) - 3);
                st -= (aa << 1) * (--y);
            }

            if (_y > 0) {
                if (_st < 0) {
                    _st += _bb * ((_x << 1) + 3);
                    _tt += (_bb << 1) * (++_x);
                    _pxb[_pxb.length] = _y - 1;
                }
                else if (_tt < 0) {
                    _st += _bb * ((_x << 1) + 3) - (_aa << 1) * (_y - 1);
                    _tt += (_bb << 1) * (++_x) - _aa * (((_y--) << 1) - 3);
                    _pxb[_pxb.length] = _y - 1;
                }
                else {
                    _tt -= _aa * ((_y << 1) - 3);
                    _st -= (_aa << 1) * (--_y);
                    _pxb[_pxb.length - 1]--;
                }
            }
        }

        var ox = 0, oy = b,
		_oy = _pxb[0],
		l = pxl.length,
		w, h;
        for (var i = 0; i < l; i++) {
            if (typeof _pxb[i] != "undefined") {
                if (_pxb[i] < _oy || pxt[i] < oy) {
                    x = pxl[i];
                    this.mkOvQds(cx, cy, -x + 1, ox + wod, -oy, _oy + hod, x - ox, oy - _oy);
                    ox = x;
                    oy = pxt[i];
                    _oy = _pxb[i];
                }
            }
            else {
                x = pxl[i];
                this.mkDiv(cx - x + 1, cy - oy, 1, (oy << 1) + hod);
                this.mkDiv(cx + ox + wod, cy - oy, 1, (oy << 1) + hod);
                ox = x;
                oy = pxt[i];
            }
        }
        this.mkDiv(cx - a, cy - oy, 1, (oy << 1) + hod);
        this.mkDiv(cx + ox + wod, cy - oy, 1, (oy << 1) + hod);
    }
}


function mkOvDott(left, top, width, height) {
    var a = width >> 1, b = height >> 1,
	wod = width & 1, hod = height & 1,
	cx = left + a, cy = top + b,
	x = 0, y = b,
	aa2 = (a * a) << 1, aa4 = aa2 << 1, bb = (b * b) << 1,
	st = (aa2 >> 1) * (1 - (b << 1)) + bb,
	tt = (bb >> 1) - aa2 * ((b << 1) - 1),
	drw = true;
    while (y > 0) {
        if (st < 0) {
            st += bb * ((x << 1) + 3);
            tt += (bb << 1) * (++x);
        }
        else if (tt < 0) {
            st += bb * ((x << 1) + 3) - aa4 * (y - 1);
            tt += (bb << 1) * (++x) - aa2 * (((y--) << 1) - 3);
        }
        else {
            tt -= aa2 * ((y << 1) - 3);
            st -= aa4 * (--y);
        }
        if (drw) this.mkOvQds(cx, cy, -x, x + wod, -y, y + hod, 1, 1);
        drw = !drw;
    }
}


function mkRect(x, y, w, h) {
    var s = this.stroke;
    this.mkDiv(x, y, w, s);
    this.mkDiv(x + w, y, s, h);
    this.mkDiv(x, y + h, w + s, s);
    this.mkDiv(x, y + s, s, h - s);
}


function mkRectDott(x, y, w, h) {
    this.drawLine(x, y, x + w, y);
    this.drawLine(x + w, y, x + w, y + h);
    this.drawLine(x, y + h, x + w, y + h);
    this.drawLine(x, y, x, y + h);
}


function jsgFont() {
    this.PLAIN = 'font-weight:normal;';
    this.BOLD = 'font-weight:bold;';
    this.ITALIC = 'font-style:italic;';
    this.ITALIC_BOLD = this.ITALIC + this.BOLD;
    this.BOLD_ITALIC = this.ITALIC_BOLD;
}
var Font = new jsgFont();


function jsgStroke() {
    this.DOTTED = -1;
}
var Stroke = new jsgStroke();


function jsGraphics(id, wnd) {
    this.setColor = new Function('arg', 'this.color = arg.toLowerCase();');

    this.setStroke = function(x) {
        this.stroke = x;
        if (!(x + 1)) {
            this.drawLine = mkLinDott;
            this.mkOv = mkOvDott;
            this.drawRect = mkRectDott;
        }
        else if (x - 1 > 0) {
            this.drawLine = mkLin2D;
            this.mkOv = mkOv2D;
            this.drawRect = mkRect;
        }
        else {
            this.drawLine = mkLin;
            this.mkOv = mkOv;
            this.drawRect = mkRect;
        }
    };


    this.setPrintable = function(arg) {
        this.printable = arg;
        if (jg_fast) {
            this.mkDiv = mkDivIe;
            this.htmRpc = arg ? htmPrtRpc : htmRpc;
        }
        else this.mkDiv = jg_n4 ? mkLyr : arg ? mkDivPrt : mkDiv;
    };


    this.setFont = function(fam, sz, sty) {
        this.ftFam = fam;
        this.ftSz = sz;
        this.ftSty = sty || Font.PLAIN;
    };


    this.drawPolyline = this.drawPolyLine = function(x, y, s) {
        for (var i = 0; i < x.length - 1; i++)
            this.drawLine(x[i], y[i], x[i + 1], y[i + 1]);
    };


    this.fillRect = function(x, y, w, h) {
        this.mkDiv(x, y, w, h);
    };


    this.drawPolygon = function(x, y) {
        this.drawPolyline(x, y);
        this.drawLine(x[x.length - 1], y[x.length - 1], x[0], y[0]);
    };


    this.drawEllipse = this.drawOval = function(x, y, w, h) {
        this.mkOv(x, y, w, h);
    };


    this.fillEllipse = this.fillOval = function(left, top, w, h) {
        var a = (w -= 1) >> 1, b = (h -= 1) >> 1,
		wod = (w & 1) + 1, hod = (h & 1) + 1,
		cx = left + a, cy = top + b,
		x = 0, y = b,
		ox = 0, oy = b,
		aa2 = (a * a) << 1, aa4 = aa2 << 1, bb = (b * b) << 1,
		st = (aa2 >> 1) * (1 - (b << 1)) + bb,
		tt = (bb >> 1) - aa2 * ((b << 1) - 1),
		pxl, dw, dh;
        if (w + 1) while (y > 0) {
            if (st < 0) {
                st += bb * ((x << 1) + 3);
                tt += (bb << 1) * (++x);
            }
            else if (tt < 0) {
                st += bb * ((x << 1) + 3) - aa4 * (y - 1);
                pxl = cx - x;
                dw = (x << 1) + wod;
                tt += (bb << 1) * (++x) - aa2 * (((y--) << 1) - 3);
                dh = oy - y;
                this.mkDiv(pxl, cy - oy, dw, dh);
                this.mkDiv(pxl, cy + y + hod, dw, dh);
                ox = x;
                oy = y;
            }
            else {
                tt -= aa2 * ((y << 1) - 3);
                st -= aa4 * (--y);
            }
        }
        this.mkDiv(cx - a, cy - oy, w + 1, (oy << 1) + hod);
    };


    /* fillPolygon method, implemented by Matthieu Haller.
    This javascript function is an adaptation of the gdImageFilledPolygon for Walter Zorn lib.
    C source of GD 1.8.4 found at http://www.boutell.com/gd/

THANKS to Kirsten Schulz for the polygon fixes!

The intersection finding technique of this code could be improved
    by remembering the previous intertersection, and by using the slope.
    That could help to adjust intersections to produce a nice
    interior_extrema. */
    this.fillPolygon = function(array_x, array_y) {
        var i;
        var y;
        var miny, maxy;
        var x1, y1;
        var x2, y2;
        var ind1, ind2;
        var ints;

        var n = array_x.length;

        if (!n) return;


        miny = array_y[0];
        maxy = array_y[0];
        for (i = 1; i < n; i++) {
            if (array_y[i] < miny)
                miny = array_y[i];

            if (array_y[i] > maxy)
                maxy = array_y[i];
        }
        for (y = miny; y <= maxy; y++) {
            var polyInts = new Array();
            ints = 0;
            for (i = 0; i < n; i++) {
                if (!i) {
                    ind1 = n - 1;
                    ind2 = 0;
                }
                else {
                    ind1 = i - 1;
                    ind2 = i;
                }
                y1 = array_y[ind1];
                y2 = array_y[ind2];
                if (y1 < y2) {
                    x1 = array_x[ind1];
                    x2 = array_x[ind2];
                }
                else if (y1 > y2) {
                    y2 = array_y[ind1];
                    y1 = array_y[ind2];
                    x2 = array_x[ind1];
                    x1 = array_x[ind2];
                }
                else continue;

                // modified 11. 2. 2004 Walter Zorn
                if ((y >= y1) && (y < y2))
                    polyInts[ints++] = Math.round((y - y1) * (x2 - x1) / (y2 - y1) + x1);

                else if ((y == maxy) && (y > y1) && (y <= y2))
                    polyInts[ints++] = Math.round((y - y1) * (x2 - x1) / (y2 - y1) + x1);
            }
            polyInts.sort(integer_compare);
            for (i = 0; i < ints; i += 2)
                this.mkDiv(polyInts[i], y, polyInts[i + 1] - polyInts[i] + 1, 1);
        }
    };


    this.drawString = function(txt, x, y) {
        this.htm += '<div style="position:absolute;white-space:nowrap;' +
			'left:' + x + 'px;' +
			'top:' + y + 'px;' +
			'font-family:' + this.ftFam + ';' +
			'font-size:' + this.ftSz + ';' +
			'color:' + this.color + ';' + this.ftSty + '">' +
			txt +
			'<\/div>';
    };


    /* drawStringRect() added by Rick Blommers.
    Allows to specify the size of the text rectangle and to align the
    text both horizontally (e.g. right) and vertically within that rectangle */
    this.drawStringRect = function(txt, x, y, width, halign) {
        this.htm += '<div style="position:absolute;overflow:hidden;' +
			'left:' + x + 'px;' +
			'top:' + y + 'px;' +
			'width:' + width + 'px;' +
			'text-align:' + halign + ';' +
			'font-family:' + this.ftFam + ';' +
			'font-size:' + this.ftSz + ';' +
			'color:' + this.color + ';' + this.ftSty + '">' +
			txt +
			'<\/div>';
    };


    this.drawImage = function(imgSrc, x, y, w, h, a) {
        this.htm += '<div style="position:absolute;' +
			'left:' + x + 'px;' +
			'top:' + y + 'px;' +
			'width:' + w + 'px;' +
			'height:' + h + 'px;">' +
			'<img src="' + imgSrc + '" width="' + w + '" height="' + h + '"' + (a ? (' ' + a) : '') + '>' +
			'<\/div>';
    };


    this.clear = function() {
        this.htm = "";
        if (this.cnv) this.cnv.innerHTML = this.defhtm;
    };


    this.mkOvQds = function(cx, cy, xl, xr, yt, yb, w, h) {
        this.mkDiv(xr + cx, yt + cy, w, h);
        this.mkDiv(xr + cx, yb + cy, w, h);
        this.mkDiv(xl + cx, yb + cy, w, h);
        this.mkDiv(xl + cx, yt + cy, w, h);
    };

    this.setStroke(1);
    this.setFont('verdana,geneva,helvetica,sans-serif', String.fromCharCode(0x31, 0x32, 0x70, 0x78), Font.PLAIN);
    this.color = '#000000';
    this.htm = '';
    this.wnd = wnd || window;

    if (!(jg_ie || jg_dom || jg_ihtm)) chkDHTM();
    if (typeof id != 'string' || !id) this.paint = pntDoc;
    else {
        this.cnv = document.all ? (this.wnd.document.all[id] || null)
			: document.getElementById ? (this.wnd.document.getElementById(id) || null)
			: null;
        this.defhtm = (this.cnv && this.cnv.innerHTML) ? this.cnv.innerHTML : '';
        this.paint = jg_dom ? pntCnvDom : jg_ie ? pntCnvIe : jg_ihtm ? pntCnvIhtm : pntCnv;
    }

    this.setPrintable(false);
}



function integer_compare(x, y) {
    return (x < y) ? -1 : ((x > y) * 1);
}

function KeyBoardEventHandler(_document) {
    var key2char = new Array();
    for (var i = 0; i < 200; i++) {
        key2char[i] = "";
    }

    key2char[9] = "Tab";
    key2char[18] = "BackSpace";
    key2char[19] = "Pause";
    key2char[20] = "CapsLock";
    key2char[27] = "Esc";

    key2char[33] = "PageUp";
    key2char[34] = "PageDown";
    key2char[35] = "End";
    key2char[36] = "Home";
    key2char[37] = "LeftArrow";
    key2char[38] = "UpArrow";
    key2char[39] = "RightArrow";
    key2char[40] = "DownArrow";
    key2char[44] = "PrtScn";
    key2char[45] = "Insert";
    key2char[46] = "Delete";
    key2char[112] = "F1";
    key2char[113] = "F2";
    key2char[114] = "F3";
    key2char[115] = "F4";
    key2char[116] = "F5";
    key2char[117] = "F6";
    key2char[118] = "F7";
    key2char[119] = "F8";
    key2char[120] = "F9";
    key2char[121] = "F10";
    key2char[122] = "F11";
    key2char[123] = "F12";

    key2char[145] = "ScrLck";

    key2char[187] = "+";
    key2char[189] = "-";

    this.doKeyDown = function(e) {
        var evt = window.event ? event : e;
        var charCode;

        //alert("Keycode: " + evt.keyCode + ", charCode: "+String.fromCharCode(evt.keyCode));

        if (evt.keyCode) {
            if (key2char[evt.keyCode] != "") {
                charCode = key2char[evt.keyCode];
            } else {
                charCode = String.fromCharCode(evt.keyCode);
            }
        } else {
            charCode = evt.which;
        }

        if (evt.altKey) {
            charCode = "Alt+" + charCode;
        } else if (evt.ctrlKey) {
            charCode = "Ctrl+" + charCode;
        } else if (evt.shiftKey) {
            charCode = "Shift+" + charCode;
        }

        // for debug
        //document.myform.text1.value = evt.keyCode;
        //document.myform.text2.value = charCode;

        if (this.kh.handler[charCode]) {
            // found handler

            //alert("About to execute "+this.kh.handler[charCode]);
            eval(this.kh.handler[charCode]);

            if (!e) {
                event.returnValue = false;
            }
            return false;
        } else {
            if (!e) {
                event.returnValue = true;
            }
            return true;
        }
    }

    this.addHandler = function(button, fn) {
        this.handler[button] = fn;
    }

    this.handler = new Array();

    _document.onkeydown = this.doKeyDown;
    _document.onkeypress = this.doKeyDown;
    _document.kh = this;
}
///////////////////////////////////////////////////////////////////////
//     This slidebar script was designed by Erik Arvidsson for WebFX //
//                                                                   //
//     Modified to make it work with Moz and Konqueror                           //
//          -Ott March 13, 2006                                                                                  //
//                                                                   //
//     For more info and examples see: http://www.eae.net/webfx/     //
//     or send mail to erik@eae.net                                  //
//                                                                   //
//     Feel free to use this code as lomg as this disclaimer is      //
//     intact.                                                       //
// $Id: slidebar.js,v 1.4 2009-06-10 09:57:17 pattara Exp $                                                              //
///////////////////////////////////////////////////////////////////////

var _sliderHandle_dragobject = null;
var _sliderHandle_type;
var onchange = "";
var _sliderHandle_tx;
var _sliderHandle_ty;
var _sliderValue = 0;

function getReal(el, type, value) {
    temp = el;
    while ((temp != null) && (temp.tagName != "BODY")) {
        if (eval("temp." + type) == value) {
            el = temp;
            return el;
        }
        temp = (temp.parentElement) ? temp.parentElement : temp.parentNode;
    }
    return el;
}

function moveme_onmousedown(e) {
    if (!e) e = window.event;

    var currentObject = (e.target) ? e.target : e.srcElement;
    var tmp = getReal(currentObject, "className", "sliderHandle");  //Traverse the element tree
    if (tmp.className == "sliderHandle") {
        _sliderHandle_dragobject = tmp;         //This is a global reference to the current dragging object

        //_sliderHandle_dragobject = (e.target)? e.target : e.srcElement;   

        onchange = _sliderHandle_dragobject.getAttribute("onchange");   //Set the onchange function
        if (onchange == null) onchange = "";
        _sliderHandle_type = _sliderHandle_dragobject.getAttribute("type");         //Find the type

        var left = _sliderHandle_dragobject.style.left.replace("px", "");
        var top = _sliderHandle_dragobject.style.top.replace("px", "");

        if (_sliderHandle_type == "y") {      //Vertical
            _sliderHandle_ty = (e.clientY - top);
        } else {            //Horizontal
            _sliderHandle_tx = (e.clientX - left);
        }

        e.returnValue = false;
        e.cancelBubble = true;
    }
    else {
        _sliderHandle_dragobject = null;    //Not draggable
    }
    return false;
}

function moveme_onmouseup(e) {
    if (_sliderHandle_dragobject) {
        var tmp = getReal(_sliderHandle_dragobject, "className", "sliderFrame");  //Traverse the element tree

        if (tmp.className == "sliderFrame") {
            var onchange = tmp.getAttribute("onchange");   //Set the onchange function
            if (onchange) {
                eval(onchange.replace(/this/g, "tmp"));
            }
        }

        _sliderHandle_dragobject = null; // clear the dragobject
    }
    return false;
}

function moveme_onmousemove(e) {
    if (!e) e = window.event;

    if (_sliderHandle_dragobject) {
        var myParent = (_sliderHandle_dragobject.parentNode) ? _sliderHandle_dragobject.parentNode : _sliderHandle_dragobject.parentElement;
        if (_sliderHandle_type == "y") {
            if (e.clientY >= 0) {
                var topvalue;

                //alert(e.clientY + ", " + myParent.clientHeight + ", " + _sliderHandle_dragobject.style.height + ", " + ty);
                var height = _sliderHandle_dragobject.style.height.replace("px", "");

                if ((e.clientY - _sliderHandle_ty > 0) && (e.clientY - _sliderHandle_ty < myParent.clientHeight - height)) {
                    topvalue = e.clientY - _sliderHandle_ty;
                }
                if (e.clientY - _sliderHandle_ty < 2) {
                    topvalue = "0";
                }
                if (e.clientY - _sliderHandle_ty > myParent.clientHeight - height - 2) {
                    topvalue = myParent.clientHeight - height
                }

                var newvalue = topvalue / (myParent.clientHeight - height);
                _sliderHandle_dragobject.style.top = topvalue + "px";
                _sliderHandle_dragobject.value = newvalue;
            }
        }
        else {
            if (e.clientX >= 0) {
                var leftvalue = 0;

                var width = _sliderHandle_dragobject.style.width.replace("px", "");

                if ((e.clientX - _sliderHandle_tx > 0) && (e.clientX - _sliderHandle_tx < myParent.clientWidth - width)) {
                    leftvalue = e.clientX - _sliderHandle_tx;
                }
                if (e.clientX - _sliderHandle_tx < 2) {
                    leftvalue = "0";
                }
                if (e.clientX - _sliderHandle_tx > myParent.clientWidth - width - 2) {
                    leftvalue = myParent.clientWidth - width;
                }

                leftvalue = (myParent.clientWidth - width) / (myParent.max - myParent.min) * Math.round(leftvalue * (myParent.max - myParent.min) / (myParent.clientWidth - width))
                var newvalue = leftvalue / (myParent.clientWidth - width);

                _sliderHandle_dragobject.style.left = leftvalue + "px";
                _sliderHandle_dragobject.value = newvalue;
                _sliderValue = newvalue
            }
        }

        // do onmoved

        var tmp = getReal(_sliderHandle_dragobject, "className", "sliderFrame");  //Traverse the element tree

        if (tmp.className == "sliderFrame") {
            var onmoved = tmp.getAttribute("onmoved");
            if (onmoved) {
                eval(onmoved.replace(/this/g, "tmp"));
            }
        }

        e.returnValue = false;
        e.cancelBubble = true;
    }
}

function block_onclick(e) {
    if (!e) e = window.event;
    var currentObject = (e.target) ? e.target : e.srcElement;
    var tmp = getReal(currentObject, "className", "sliderFrame");   //Traverse the element tree

    var myParent = (tmp.sliderbutton.parentNode) ? tmp.sliderbutton.parentNode : tmp.sliderbutton.parentElement;
    var blockarea = (tmp.clientWidth / tmp.sliderbutton.clientWidth); //7
    var usearea = (tmp.clientWidth - tmp.sliderbutton.clientWidth); //120
    chkWinSize();
    //var tempvar = ww - tmp.style.right.replace("px","") - tmp.clientWidth;
    var tempvar = tmp.offsetLeft;
    //alert(e.clientX);
    //alert(tmp.offsetLeft);

    if (e.clientX - tempvar > tmp.sliderbutton.value * usearea + 1.0 * tmp.sliderbutton.clientWidth) {
        val = tmp.sliderbutton.value + (1 / (tmp.sliderbuttonMax - tmp.sliderbuttonMin));
    } else if (e.clientX - tempvar < tmp.sliderbutton.value * usearea + 0.5 * tmp.sliderbutton.clientWidth) {
        val = tmp.sliderbutton.value - (1 / (tmp.sliderbuttonMax - tmp.sliderbuttonMin));
    } else {
        val = tmp.sliderbutton.value;
    }
    if (val < 0) val = 0;
    if (val > 1) val = 1;
    tmp.sliderbutton.style.left = val * (myParent.clientWidth - tmp.sliderbutton.style.width.replace("px", "")) + 0.00001;
    tmp.sliderbutton.value = val;
    _sliderValue = val;

    var onchange = tmp.getAttribute("onchange");
    eval(onchange.replace(/this/g, "tmp"));
    return false;
}

/*
function Slider(_sliderDiv,_min,_max,_parent) {

this.sliderDiv = _sliderDiv;
this.min = _min;
this.max = _max;
_parent.sliderbutton = _sliderDiv;
_parent.sliderbuttonMin = _min;
_parent.sliderbuttonMax = _max;
this.parent = _parent;

//this.parent.onclick = block_onclick;
this.sliderDiv.myObject = this;
this.sliderDiv.onmousedown = moveme_onmousedown;

this.getValue = function() {
return Math.round(this.sliderDiv.value*(this.max - this.min) + this.min);
};

this.setValue = function(val) {
val = (val-this.min)/(this.max - this.min);
this.sliderDiv.value = val;

var myParent = (this.sliderDiv.parentNode) ? this.sliderDiv.parentNode : this.sliderDiv.parentElement;
myParent.min = _min;
myParent.max = _max;
if (this.sliderDiv.getAttribute("TYPE") == "x") {
this.sliderDiv.style.left =  val * (myParent.clientWidth - this.sliderDiv.style.width.replace("px",""));
}
else {
this.sliderDiv.style.top =  val * (myParent.clientHeight - this.sliderDiv.style.pixelHeight);
}
//eval(el.onchange.replace(/this/g, "el"))
}
}
*/

function Slider(_sliderboxDiv, _width, _height, _min, _max) {
    this.sliderboxDiv = _sliderboxDiv;
    this.sliderboxDiv.style.width = _width + "px";
    this.sliderboxDiv.style.height = _height + "px";
    this.sliderboxDiv.style.position = "absolute";
    //this.sliderboxDiv.style.position = "relative"; // FIXME should be relative
    //_sliderboxDiv.style.border = "0px";
    this.sliderboxDiv.className = "sliderFrame";

    var slider = document.createElement("DIV");
    this.sliderDiv = slider;
    this.sliderDiv.className = "sliderHandle";
    this.sliderDiv.style.type = "x";
    this.sliderDiv.style.width = _height + "px";
    this.sliderDiv.style.height = _height + "px";
    this.sliderDiv.style.position = "relative";
    //slider.style.border = "0px";
    this.sliderDiv.style.left = "0px";
    this.sliderDiv.style.top = "0px";
    this.sliderDiv.style.background = "#3f8cff";
    this.sliderDiv.style.border = "1px solid black";
    this.sliderDiv.style.zIndex = 3;
    this.sliderDiv.onmousedown = moveme_onmousedown;

    this.sliderDiv.onmouseover = function() {
        this.style.border = "2px solid #ffd800";
    };

    this.sliderDiv.onmouseout = function() {
        this.style.border = "1px solid black";
    };
    this.sliderboxDiv.appendChild(this.sliderDiv);

    this.sliderboxDiv.myObject = this;
    this.sliderboxDiv.onmousedown = block_onclick;
    this.sliderboxDiv.sliderbutton = this.sliderDiv;
    this.sliderboxDiv.sliderbuttonMin = _min;
    this.sliderboxDiv.sliderbuttonMax = _max;

    var middlebar = document.createElement("DIV");
    middlebar.style.border = "1px solid black";
    middlebar.style.position = "absolute";
    middlebar.style.top = "8px";
    middlebar.style.left = "-2px";
    middlebar.style.overflow = "hidden";
    middlebar.style.width = this.sliderboxDiv.style.width;
    middlebar.style.background = "#ffffff";
    //middlebar.style.background = "#cbc6c6";
    //alert(middlebar.style.width);
    middlebar.style.height = "4px";
    middlebar.style.zIndex = 2;

    // IE sucks
    //middlebar.style.bottommargin = "0px";
    middlebar.style.padding = "0px 0px 0px 0px";

    //alert(middlebar.style.height);
    this.sliderboxDiv.appendChild(middlebar);

    //var iqueslider = new Slider(this.sliderDiv,_min,_max,this.sliderboxDiv);

    this.getValue = function() {
        return Math.round(this.sliderDiv.value * (_max - _min) + _min);
    };

    this.setValue = function(val) {
        val = (val - _min) / (_max - _min);
        _sliderValue = val;
        this.sliderDiv.value = val;
        var myParent = (this.sliderDiv.parentNode) ? this.sliderDiv.parentNode : this.sliderDiv.parentElement;
        myParent.min = _min;
        myParent.max = _max;
        myParent.width = myParent.style.width ? myParent.style.width.replace("px", "") : myParent.clientWidth;
        //var newpos =  val * (myParent.clientWidth - this.sliderDiv.style.width.replace("px",""));
        var newpos = val * (myParent.width - this.sliderDiv.style.width.replace("px", ""));
        this.sliderDiv.style.left = newpos + "px";
    }
}

//document.onmouseup = moveme_onmouseup;
//document.onmousemove = moveme_onmousemove;
if (window.addEventListener) { // Mozilla, Netscape, Firefox
    document.addEventListener('mouseup', moveme_onmouseup, false);
    document.addEventListener('mousemove', moveme_onmousemove, false);
} else { // IE
    document.attachEvent('onmouseup', moveme_onmouseup);
    document.attachEvent('onmousemove', moveme_onmousemove);
}

document.write('<style type="text/css">\
        .sliderHandle   {position: relative; cursor: default;}\
        </style>');

function tgbase32todec(_base32) {
    var alphabets = "abcdefghijklmnopqrstuvwxyz234567";
    _base32 = _base32.toLowerCase();
    var i;
    var result = 0;
    var digit = 0;
    for (i = _base32.length - 1; i >= 0; i--) {
        var val = alphabets.indexOf(_base32.charAt(i));
        if (val == -1) {
            return -1;
        }
        result += Math.pow(32, digit) * val;
        digit++;
    }
    return result;
}

function tgdectobase32(_dec) {
    var alphabets = "abcdefghijklmnopqrstuvwxyz234567";

    if (_dec <= 0) {
        return "";
    }

    var result = "";
    while (_dec > 0) {
        var modresult = _dec % 32;
        result = alphabets.charAt(modresult) + result;
        _dec = parseInt(_dec / 32);
    }

    return result.toUpperCase();
}

// Browser Detection
// From http://www.quirksmode.org/js/detect.html

var BrowserDetect = {
    init: function() {
        this.browser = this.searchString(this.dataBrowser) || "An unknown browser";
        this.version = this.searchVersion(navigator.userAgent)
			|| this.searchVersion(navigator.appVersion)
			|| "an unknown version";
        this.OS = this.searchString(this.dataOS) || "an unknown OS";
    },
    searchString: function(data) {
        for (var i = 0; i < data.length; i++) {
            var dataString = data[i].string;
            var dataProp = data[i].prop;
            this.versionSearchString = data[i].versionSearch || data[i].identity;
            if (dataString) {
                if (dataString.indexOf(data[i].subString) != -1)
                    return data[i].identity;
            }
            else if (dataProp)
                return data[i].identity;
        }
    },
    searchVersion: function(dataString) {
        var index = dataString.indexOf(this.versionSearchString);
        if (index == -1) return;
        return parseFloat(dataString.substring(index + this.versionSearchString.length + 1));
    },
    dataBrowser: [
		{ string: navigator.userAgent,
		    subString: "OmniWeb",
		    versionSearch: "OmniWeb/",
		    identity: "OmniWeb"
		},
		{
		    string: navigator.vendor,
		    subString: "Safari",
		    identity: "Safari"
		},
		{
		    prop: window.opera,
		    identity: "Opera"
		},
		{
		    string: navigator.vendor,
		    subString: "iCab",
		    identity: "iCab"
		},
		{
		    string: navigator.vendor,
		    subString: "KDE",
		    identity: "Konqueror"
		},
		{
		    string: navigator.userAgent,
		    subString: "Firefox",
		    identity: "Firefox"
		},
		{
		    string: navigator.userAgent,
		    subString: "Iceweasel",
		    versionSearch: "Iceweasel",
		    identity: "Firefox"
		},
		{
		    string: navigator.vendor,
		    subString: "Camino",
		    identity: "Camino"
		},
		{		// for newer Netscapes (6+)
		    string: navigator.userAgent,
		    subString: "Netscape",
		    identity: "Netscape"
		},
		{
		    string: navigator.userAgent,
		    subString: "MSIE",
		    identity: "Explorer",
		    versionSearch: "MSIE"
		},
		{
		    string: navigator.userAgent,
		    subString: "BonEcho",
		    versionSearch: "BonEcho",
		    identity: "Firefox"
		},
		{
		    string: navigator.userAgent,
		    subString: "Gecko",
		    identity: "Mozilla",
		    versionSearch: "rv"
		},
		{ 		// for older Netscapes (4-)
		    string: navigator.userAgent,
		    subString: "Mozilla",
		    identity: "Netscape",
		    versionSearch: "Mozilla"
		}
	],
    dataOS: [
		{
		    string: navigator.platform,
		    subString: "Win",
		    identity: "Windows"
		},
		{
		    string: navigator.platform,
		    subString: "Mac",
		    identity: "Mac"
		},
		{
		    string: navigator.platform,
		    subString: "Linux",
		    identity: "Linux"
		}
	]

};
BrowserDetect.init();
//svg_vml-edit

//----------------------------------------------------------------------------
// AbstractRenderer
//
// Abstract base class defining the drawing API. Can not be used directly.
//----------------------------------------------------------------------------

//{{{ AbstractRenderer()
function AbstractRenderer() {

} //}}};

AbstractRenderer.prototype.init = function(elem) { };
AbstractRenderer.prototype.bounds = function(shape) { return { x: 0, y: 0, width: 0, height: 0 }; };
AbstractRenderer.prototype.create = function(shape, fillColor, lineColor, lineWidth, left, top, width, height, opac, bgopac) { };
AbstractRenderer.prototype.remove = function(shape) { };
AbstractRenderer.prototype.move = function(shape, left, top) { };
AbstractRenderer.prototype.track = function(shape) { };
AbstractRenderer.prototype.resize = function(shape, fromX, fromY, toX, toY) { };
AbstractRenderer.prototype.editCommand = function(shape, cmd, value) { };
AbstractRenderer.prototype.queryCommand = function(shape, cmd) { };
AbstractRenderer.prototype.showTracker = function(shape) { };
AbstractRenderer.prototype.getMarkup = function() { return null; };

AbstractRenderer.prototype.createpoly = function(fillColor, lineColor, lineWidth, points, opac, bgopac) { };   //----add----------------------------bgopac









//{{{ VMLRenderer()
/*----------------------------------------------------------------------------
VMLRENDERER 1.0
VML Renderer For RichDraw
-----------------------------------------------------------------------------
Created by Mark Finkle (mark.finkle@gmail.com)
Implementation of VML based renderer.
-----------------------------------------------------------------------------
Copyright (c) 2006 Mark Finkle

This program is  free software;  you can redistribute  it and/or  modify it
under the terms of the MIT License.

Permission  is hereby granted,  free of charge, to  any person  obtaining a
copy of this software and associated documentation files (the "Software"),
to deal in the  Software without restriction,  including without limitation
the  rights to use, copy, modify,  merge, publish, distribute,  sublicense,
and/or  sell copies  of the  Software, and to  permit persons to  whom  the
Software is  furnished  to do  so, subject  to  the  following  conditions:
The above copyright notice and this  permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS",  WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED,  INCLUDING BUT NOT LIMITED TO  THE WARRANTIES  OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR  COPYRIGHT  HOLDERS BE  LIABLE FOR  ANY CLAIM,  DAMAGES OR OTHER
LIABILITY, WHETHER  IN AN  ACTION OF CONTRACT, TORT OR  OTHERWISE,  ARISING
FROM,  OUT OF OR  IN  CONNECTION  WITH  THE  SOFTWARE OR THE  USE OR  OTHER
DEALINGS IN THE SOFTWARE.
-----------------------------------------------------------------------------
Dependencies:
History:
2006-04-05 | Created
--------------------------------------------------------------------------*/


function VMLRenderer() {
    this.base = AbstractRenderer;
} //}}}


VMLRenderer.prototype = new AbstractRenderer;


VMLRenderer.prototype.init = function(elem) {
    this.container = elem;

    this.container.style.overflow = 'hidden';

    // Add VML includes and namespace
    if (!elem.ownerDocument.vmlinitonceflag) {
        elem.ownerDocument.vmlinitonceflag = true;

        // This line causes IE error -- Ott 20071012
        //elem.ownerDocument.namespaces.add("v", "urn:schemas-microsoft-com:vml");
        if (typeof elem.ownerDocument.namespaces != "undefined") {
            setTimeout('document.namespaces.add("v", "urn:schemas-microsoft-com:vml")', 10);
        }

        var style = elem.ownerDocument.createStyleSheet();
        try {
            //This make script error in IE8
            style.addRule('v\\:*', "behavior: url(#default#VML);");
        } catch (e) {
            style.addRule('v\\:polyline', 'behavior: url(#default#VML);');
            style.addRule('v\\:fill', 'behavior: url(#default#VML);');
            style.addRule('v\\:stroke', 'behavior: url(#default#VML);');
        }
    }
}


VMLRenderer.prototype.bounds = function(shape) {
    var rect = new Object();
    rect['x'] = shape.offsetLeft;
    rect['y'] = shape.offsetTop;
    rect['width'] = shape.offsetWidth;
    rect['height'] = shape.offsetHeight;
    return rect;
}


VMLRenderer.prototype.create = function(shape, fillColor, lineColor, lineWidth, left, top, width, height, opac, bgopac, lineobject) {
    var vml;
    if (shape == 'rect') {
        vml = this.container.ownerDocument.createElement('v:rect');
    }
    else if (shape == 'roundrect') {
        vml = this.container.ownerDocument.createElement('v:roundrect');
    }
    else if (shape == 'ellipse') {
        vml = this.container.ownerDocument.createElement('v:oval');
    }
    else if (shape == 'line') {
        vml = this.container.ownerDocument.createElement('v:line');
    }
    if (typeof (lineobject) != 'undefined') {
        vml.lineobject = lineobject;
        if (typeof (lineobject.zIndex) != 'undefined') {
            vml.style.zIndex = lineobject.zIndex;
        }
    }
    if (shape != 'line') {
        vml.style.position = 'absolute';
        vml.style.left = left;
        vml.style.top = top;
        vml.style.width = width;
        vml.style.height = height;

        if (typeof (fillColor) != 'undefined' && fillColor != '') {
            vml.setAttribute('filled', 'true');
            vml.setAttribute('fillcolor', fillColor);
            if (typeof (bgopac) != 'undefined') bgopac = '0.5';
            if (typeof (lineobject) != 'undefined' && typeof (lineobject.fillopacity) != 'undefined') bgopac = lineobject.fillopacity;
            //if(typeof(bgopac)!='undefined') vml.innerHTML += '<v:fill opacity="'+(bgopac)+'" />';  // extra
        }
        else {
            vml.setAttribute('filled', 'false');
        }

    }
    else {
        vml.style.position = 'absolute';
        vml.setAttribute('from', left + 'px,' + top + 'px');
        vml.setAttribute('to', (width + left) + 'px,' + (height + top) + 'px');
        //------------------fill shape color----------------------------
        if (lineobject.mode == 0) {
            if (typeof (bgopac) != 'undefined')
                bgopac = '50%';
            else
                bgopac = (bgopac * 100) + '%';
            vml.setAttribute('opacity', bgopac);
        }
        else {

        }
        /*if(typeof(lineobject)!='undefined') {
        if(typeof(lineobject.fillopacity))
        }*/
        //------------------------------------------------------
    }
    if (lineColor != '') {
        vml.setAttribute('stroked', 'true');
        vml.setAttribute('strokecolor', lineColor);
        vml.setAttribute('strokeweight', lineWidth);
    }
    else {
        vml.setAttribute('stroked', 'false');
    }

    if (typeof (opac) != 'undefined' && opac < 1) {
        //vml.innerHTML += "<v:stroke opacity=\""+(opac)+"\" />";
    }

    this.container.appendChild(vml);
    //fill opacity and stroke opacity are not work with oval
    //to be fix...
    if (typeof (bgopac) != 'undefined') this.container.gs.editCommand(vml, 'fillopacity', bgopac);
    if (typeof (opac) != 'undefined') this.container.gs.editCommand(vml, 'lineopacity', opac);

    return vml;
};

VMLRenderer.prototype.createpoly = function(fillColor, lineColor, lineWidth, points, opac, bgopac, lineobject) {
    var vml;
    var vmla = new Array();

    cmd = "";
    cmda = new Array();
    for (var i = 0; i < points.length; i++) {
        if (points[i][2] == 1) {
            cmda[cmda.length] = cmd;
            cmd = "";
        }
        cmd += " " + points[i][0] + " " + points[i][1];
    }

    if (cmd != "") cmda[cmda.length] = cmd;

    for (var i = 0; i < cmda.length; i++) {
        vml = this.container.ownerDocument.createElement('v:polyline');

        vml.style.position = 'absolute';
        vml.style.left = 0;
        vml.style.top = 0;
        //vml.style.cursor = 'pointer'; // test add
        vml.setAttribute('points', cmda[i]);

        //attach lineobject to VML line
        if (typeof (lineobject) != 'undefined') {
            vml.lineobject = lineobject;
            fillColor = lineobject.fillcolor;
            lineColor = lineobject.linecolor;
            bgopac = lineobject.fillopacity;
            if (typeof (lineobject.linewidth) != 'undefined')
                lineWidth = lineobject.linewidth;
            if (typeof (lineobject.lineopacity) != 'undefined')
                opac = lineobject.lineopacity;
        }
        //------------------fill shape color----------------------------
        if (typeof (lineobject) != 'undefined' && typeof (lineobject.mode) != 'undefined' && lineobject.mode == 0) {
            if (typeof (fillColor) != 'undefined') {
                vml.setAttribute('filled', 'true');
                vml.setAttribute('fillcolor', fillColor);
            }
        }
        else {
            vml.setAttribute('filled', 'false');
        }
        //------------------------------------------------------

        if (lineColor != '') {
            vml.setAttribute('stroked', 'true');
            vml.setAttribute('strokecolor', lineColor);
            vml.setAttribute('strokeweight', lineWidth);
        }
        else {
            vml.setAttribute('stroked', 'false');
        }
        if (opac <= 1) {
            try {
                //opac = 0.2 // force it :(
                vml.innerHTML += "<v:stroke opacity=\"" + (opac) + "\" />"; // opac <--- org
                if (typeof (bgopac) != 'undefined') vml.innerHTML += '<v:fill opacity="' + (bgopac) + '" />';  // extra
            } catch (err) { };
        }

        this.container.appendChild(vml);

        vmla[vmla.length] = vml;
    }

    return vmla;
};


VMLRenderer.prototype.remove = function(shape) {
    shape.removeNode(true);
}


VMLRenderer.prototype.move = function(shape, left, top) {
    if (shape.tagName == 'line') {
        shape.style.marginLeft = left;
        shape.style.marginTop = top;
    }
    else {
        shape.style.left = left;
        shape.style.top = top;
    }
};


VMLRenderer.prototype.track = function(shape) {
    // TODO
};


VMLRenderer.prototype.resize = function(shape, fromX, fromY, toX, toY) {
    var deltaX = toX - fromX;
    var deltaY = toY - fromY;

    if (shape.tagName == 'line') {
        shape.setAttribute('to', toX + 'px,' + toY + 'px');
    }
    else {
        if (deltaX < 0) {
            shape.style.left = toX + 'px';
            shape.style.width = -deltaX + 'px';
        }
        else {
            shape.style.width = deltaX + 'px';
        }

        if (deltaY < 0) {
            shape.style.top = toY + 'px';
            shape.style.height = -deltaY + 'px';
        }
        else {
            shape.style.height = deltaY + 'px';
        }
    }
};


VMLRenderer.prototype.editCommand = function(shape, cmd, value) {
    if (shape != null) {
        if (cmd == 'fillcolor') {
            if (value != '') {
                shape.filled = 'true';
                shape.fillcolor = value;
            }
            else {
                shape.filled = 'false';
                shape.fillcolor = '';
            }
        }
        else if (cmd == 'linecolor') {
            if (value != '') {
                shape.stroked = 'true';
                shape.strokecolor = value;
            }
            else {
                shape.stroked = 'false';
                shape.strokecolor = '';
            }
        }
        else if (cmd == 'linewidth') {
            shape.strokeweight = parseInt(value) + 'px';
        }
        else if (cmd == 'lineopacity') {
            if (shape.stroke) {
                shape.stroke.opacity = value;
            }
        }
        else if (cmd == 'fillopacity') {
            if (shape.fill) {
                shape.fill.opacity = value;
            }
        }
    }
}


VMLRenderer.prototype.queryCommand = function(shape, cmd) {
    if (shape != null) {
        if (cmd == 'fillcolor') {
            if (shape.filled == 'false')
                return '';
            else
                return shape.fillcolor;
        }
        else if (cmd == 'linecolor') {
            if (shape.stroked == 'false')
                return '';
            else
                return shape.strokecolor;
        }
        else if (cmd == 'linewidth') {
            if (shape.stroked == 'false') {
                return '';
            }
            else {
                // VML always transforms the pixels to points, so we have to convert them back
                return (parseFloat(shape.strokeweight) * (screen.logicalXDPI / 72)) + 'px';
            }
        }
    }
}


VMLRenderer.prototype.showTracker = function(shape) {
    var box = this.bounds(shape);

    var tracker = document.getElementById('tracker');
    if (tracker) {
        this.remove(tracker);
    }

    tracker = this.container.ownerDocument.createElement('v:rect');
    tracker.id = 'tracker';
    tracker.style.position = 'absolute';
    tracker.style.left = box.x - 10;
    tracker.style.top = box.y - 10;
    tracker.style.width = box.width + 20;
    tracker.style.height = box.height + 20;
    tracker.setAttribute('filled', 'false');
    tracker.setAttribute('stroked', 'true');
    tracker.setAttribute('strokecolor', 'blue');
    tracker.setAttribute('strokeweight', '1px');
    this.container.appendChild(tracker);
}


VMLRenderer.prototype.getMarkup = function() {
    return this.container.innerHTML;
}










//{{{ SVGRenderer()
/*----------------------------------------------------------------------------
SVGRENDERER 1.0
SVG Renderer For RichDraw
-----------------------------------------------------------------------------
Created by Mark Finkle (mark.finkle@gmail.com)
Implementation of SVG based renderer.
-----------------------------------------------------------------------------
Copyright (c) 2006 Mark Finkle

This program is  free software;  you can redistribute  it and/or  modify it
under the terms of the MIT License.

Permission  is hereby granted,  free of charge, to  any person  obtaining a
copy of this software and associated documentation files (the "Software"),
to deal in the  Software without restriction,  including without limitation
the  rights to use, copy, modify,  merge, publish, distribute,  sublicense,
and/or  sell copies  of the  Software, and to  permit persons to  whom  the
Software is  furnished  to do  so, subject  to  the  following  conditions:
The above copyright notice and this  permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS",  WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED,  INCLUDING BUT NOT LIMITED TO  THE WARRANTIES  OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR  COPYRIGHT  HOLDERS BE  LIABLE FOR  ANY CLAIM,  DAMAGES OR OTHER
LIABILITY, WHETHER  IN AN  ACTION OF CONTRACT, TORT OR  OTHERWISE,  ARISING
FROM,  OUT OF OR  IN  CONNECTION  WITH  THE  SOFTWARE OR THE  USE OR  OTHER
DEALINGS IN THE SOFTWARE.
-----------------------------------------------------------------------------
Dependencies:
History:
2006-04-05 | Created
--------------------------------------------------------------------------*/


function SVGRenderer() {
    this.base = AbstractRenderer;
    this.svgRoot = null;
} //}}}


SVGRenderer.prototype = new AbstractRenderer;


SVGRenderer.prototype.init = function(elem) {
    this.container = elem;

    this.container.style.MozUserSelect = 'none';

    var svgNamespace = 'http://www.w3.org/2000/svg';
    this.svgRoot = this.container.ownerDocument.createElementNS(svgNamespace, "svg");
    this.svgRoot.setAttribute('height', this.container.offsetHeight);
    this.svgRoot.setAttribute('width', this.container.offsetWidth);
    this.container.appendChild(this.svgRoot);
}


SVGRenderer.prototype.bounds = function(shape) {
    var rect = new Object();
    var box = shape.getBBox();
    rect['x'] = box.x;
    rect['y'] = box.y;
    rect['width'] = box.width;
    rect['height'] = box.height;
    return rect;
}


SVGRenderer.prototype.create = function(shape, fillColor, lineColor, lineWidth, left, top, width, height, opac, bgopac, lineobject) {
    var svgNamespace = 'http://www.w3.org/2000/svg';
    var svg;

    if (shape == 'rect') {
        svg = this.container.ownerDocument.createElementNS(svgNamespace, 'rect');
        svg.setAttributeNS(null, 'x', left + 'px');
        svg.setAttributeNS(null, 'y', top + 'px');
        svg.setAttributeNS(null, 'width', width + 'px');
        svg.setAttributeNS(null, 'height', height + 'px');
    }
    else if (shape == 'ellipse') {
        svg = this.container.ownerDocument.createElementNS(svgNamespace, 'ellipse');
        svg.setAttributeNS(null, 'cx', (left + width / 2) + 'px');
        svg.setAttributeNS(null, 'cy', (top + height / 2) + 'px');
        svg.setAttributeNS(null, 'rx', (width / 2) + 'px');
        svg.setAttributeNS(null, 'ry', (height / 2) + 'px');
    }
    else if (shape == 'roundrect') {
        svg = this.container.ownerDocument.createElementNS(svgNamespace, 'rect');
        svg.setAttributeNS(null, 'x', left + 'px');
        svg.setAttributeNS(null, 'y', top + 'px');
        svg.setAttributeNS(null, 'rx', '20px');
        svg.setAttributeNS(null, 'ry', '20px');
        svg.setAttributeNS(null, 'width', width + 'px');
        svg.setAttributeNS(null, 'height', height + 'px');
    }
    else if (shape == 'line') {
        svg = this.container.ownerDocument.createElementNS(svgNamespace, 'line');
        svg.setAttributeNS(null, 'x1', left + 'px');
        svg.setAttributeNS(null, 'y1', top + 'px');
        svg.setAttributeNS(null, 'fill', fillColor);

        //    svg.setAttributeNS(null, 'x2', left + 'px');
        //    svg.setAttributeNS(null, 'y2', top + 'px');
        svg.setAttributeNS(null, 'x2', (width + left) + 'px');
        svg.setAttributeNS(null, 'y2', (height + top) + 'px');
    }
    if (typeof (lineobject) != 'undefined') {
        svg.lineobject = lineobject;
    }
    svg.style.position = 'absolute';

    if (typeof (fillColor) != 'undefined') {
        if (fillColor.length == 0)
            fillColor = 'none';
        svg.setAttributeNS(null, 'fill', fillColor);
        if (typeof (bgopac) != 'undefined') {
            svg.setAttributeNS(null, 'fill-opacity', bgopac);
        }
    } else {
        svg.setAttributeNS(null, 'fill', 'none');
    }



    if (opac < 1) {
        svg.setAttributeNS(null, 'stroke-opacity', opac);
    }

    if (lineColor.length == 0)
        lineColor = 'none';
    svg.setAttributeNS(null, 'stroke', lineColor);
    svg.setAttributeNS(null, 'stroke-width', lineWidth);

    this.svgRoot.appendChild(svg);

    return svg;
};


SVGRenderer.prototype.createpoly = function(fillColor, lineColor, lineWidth, points, opac, bgopac, lineobject, handler) {
    cmd = "M" + points[0][0] + " " + points[0][1];
    for (i = 1; i < points.length; i++) {
        cmd += " " + ((points[i][2] == 1) ? "M" : "L") + points[i][0] + " " + points[i][1];
    }

    var svgNamespace = 'http://www.w3.org/2000/svg';
    var svg;

    svg = this.container.ownerDocument.createElementNS(svgNamespace, 'path');
    svg.style.position = 'absolute';
    //svg.style.cursor = 'pointer';

    if (!bgopac) bgopac = 0.5;
    if (lineColor.length == 0) {
        lineColor = 'none';
    }
    if (typeof (lineobject) != 'undefined') {
        lineColor = lineobject.linecolor;
        fillColor = lineobject.fillcolor;
        bgopac = lineobject.fillopacity;
        if (typeof (lineobject.lineopacity) != 'undefined')
            opac = lineobject.lineopacity;
        if (typeof (lineobject.linewidth) != 'undefined')
            lineWidth = lineobject.linewidth;
    }


    if (typeof (lineobject) != 'undefined') {
        if (typeof (fillColor) == 'undefined') {
            fillColor = 'none';
        }
    }
    if (fillColor.length == 0 || (lineobject && lineobject.mode == 1)) {
        fillColor = 'none';
    }
    svg.setAttributeNS(null, 'd', cmd);

    //------------------fill shape color----------------------------
    svg.setAttributeNS(null, 'fill', fillColor);
    svg.setAttributeNS(null, 'fill-opacity', bgopac);


    if (handler.onmouseover) svg.setAttributeNS(null, 'onmouseover', handler.onmouseover);
    if (handler.onmouseout) svg.setAttributeNS(null, 'onmouseout', handler.onmouseout);
    //------------------------------------------------------
    //attach line object to SVG line
    if (typeof (lineobject) != 'undefined') {
        svg.lineobject = lineobject;
    }

    svg.setAttributeNS(null, 'stroke', lineColor);
    svg.setAttributeNS(null, 'stroke-width', lineWidth);

    svg.setAttributeNS(null, 'stroke-linecap', 'round');
    svg.setAttributeNS(null, 'stroke-linejoin', 'round');

    if (opac < 1) {
        svg.setAttributeNS(null, 'stroke-opacity', opac);
    }

    this.svgRoot.appendChild(svg);

    return svg;
};

SVGRenderer.prototype.remove = function(shape) {
    shape.parentNode.removeChild(shape);
}


SVGRenderer.prototype.move = function(shape, left, top) {
    if (shape.tagName == 'line') {
        var deltaX = shape.getBBox().width;
        var deltaY = shape.getBBox().height;
        shape.setAttributeNS(null, 'x1', left);
        shape.setAttributeNS(null, 'y1', top);
        shape.setAttributeNS(null, 'x2', left + deltaX);
        shape.setAttributeNS(null, 'y2', top + deltaY);
    }
    else if (shape.tagName == 'ellipse') {
        shape.setAttributeNS(null, 'cx', left + (shape.getBBox().width / 2));
        shape.setAttributeNS(null, 'cy', top + (shape.getBBox().height / 2));
    }
    else {
        shape.setAttributeNS(null, 'x', left);
        shape.setAttributeNS(null, 'y', top);
    }
};


SVGRenderer.prototype.track = function(shape) {
    // TODO
};


SVGRenderer.prototype.resize = function(shape, fromX, fromY, toX, toY) {
    var deltaX = toX - fromX;
    var deltaY = toY - fromY;

    if (shape.tagName == 'line') {
        shape.setAttributeNS(null, 'x2', toX);
        shape.setAttributeNS(null, 'y2', toY);
    }
    else if (shape.tagName == 'ellipse') {
        if (deltaX < 0) {
            shape.setAttributeNS(null, 'cx', (fromX + deltaX / 2) + 'px');
            shape.setAttributeNS(null, 'rx', (-deltaX / 2) + 'px');
        }
        else {
            shape.setAttributeNS(null, 'cx', (fromX + deltaX / 2) + 'px');
            shape.setAttributeNS(null, 'rx', (deltaX / 2) + 'px');
        }

        if (deltaY < 0) {
            shape.setAttributeNS(null, 'cy', (fromY + deltaY / 2) + 'px');
            shape.setAttributeNS(null, 'ry', (-deltaY / 2) + 'px');
        }
        else {
            shape.setAttributeNS(null, 'cy', (fromY + deltaY / 2) + 'px');
            shape.setAttributeNS(null, 'ry', (deltaY / 2) + 'px');
        }
    }
    else {
        if (deltaX < 0) {
            shape.setAttributeNS(null, 'x', toX + 'px');
            shape.setAttributeNS(null, 'width', -deltaX + 'px');
        }
        else {
            shape.setAttributeNS(null, 'width', deltaX + 'px');
        }

        if (deltaY < 0) {
            shape.setAttributeNS(null, 'y', toY + 'px');
            shape.setAttributeNS(null, 'height', -deltaY + 'px');
        }
        else {
            shape.setAttributeNS(null, 'height', deltaY + 'px');
        }
    }
};


SVGRenderer.prototype.editCommand = function(shape, cmd, value) {
    if (shape != null) {
        if (cmd == 'fillcolor') {
            if (value != '')
                shape.setAttributeNS(null, 'fill', value);
            else
                shape.setAttributeNS(null, 'fill', 'none');
        }
        else if (cmd == 'linecolor') {
            if (value != '')
                shape.setAttributeNS(null, 'stroke', value);
            else
                shape.setAttributeNS(null, 'stroke', 'none');
        }
        else if (cmd == 'linewidth') {
            shape.setAttributeNS(null, 'stroke-width', parseInt(value) + 'px');
        }
        else if (cmd == 'lineopacity') {
            //stroke-opacity
            if (value != '')
                shape.setAttributeNS(null, 'stroke-opacity', value);
        }
        else if (cmd == 'fillopacity') {
            //stroke-opacity
            if (value != '')
                shape.setAttributeNS(null, 'fill-opacity', value);
        }
    }
}


SVGRenderer.prototype.queryCommand = function(shape, cmd) {
    var result = '';

    if (shape != null) {
        if (cmd == 'fillcolor') {
            result = shape.getAttributeNS(null, 'fill');
            if (result == 'none')
                result = '';
        }
        else if (cmd == 'linecolor') {
            result = shape.getAttributeNS(null, 'stroke');
            if (result == 'none')
                result = '';
        }
        else if (cmd == 'linewidth') {
            result = shape.getAttributeNS(null, 'stroke');
            if (result == 'none')
                result = '';
            else
                result = shape.getAttributeNS(null, 'stroke-width');
        }
    }

    return result;
}


SVGRenderer.prototype.showTracker = function(shape) {
    var box = shape.getBBox();

    var tracker = document.getElementById('tracker');
    if (tracker) {
        this.remove(tracker);
    }

    var svgNamespace = 'http://www.w3.org/2000/svg';

    tracker = document.createElementNS(svgNamespace, 'rect');
    tracker.setAttributeNS(null, 'id', 'tracker');
    tracker.setAttributeNS(null, 'x', box.x - 10);
    tracker.setAttributeNS(null, 'y', box.y - 10);
    tracker.setAttributeNS(null, 'width', box.width + 20);
    tracker.setAttributeNS(null, 'height', box.height + 20);
    tracker.setAttributeNS(null, 'fill', 'none');
    tracker.setAttributeNS(null, 'stroke', 'blue');
    tracker.setAttributeNS(null, 'stroke-width', '1');
    this.svgRoot.appendChild(tracker);
}


SVGRenderer.prototype.getMarkup = function() {
    return this.container.innerHTML;
}
/*******************************************
*
* This file contains Wrapper for Libraries:
* - Mark Finkle http://starkravingfinkle.org/
* - Walter Zorn http://www.walterzorn.com/
*
*******************************************/

function allgs(cnv) {
    var engine = "wz";
    var fgcolor, bgcolor, linewidth, opacity, bgopacity;

    this.cnv = cnv;
    if ((BrowserDetect.browser == "Explorer") && (BrowserDetect.version >= 5)) {
        engine = "vml";
    } else if (((BrowserDetect.browser == "Firefox") && (BrowserDetect.version >= 2)) ||
							((BrowserDetect.browser == "Opera") && (BrowserDetect.version >= 8)) ||
							((BrowserDetect.browser == "Safari") && (BrowserDetect.version >= 0)) ||
							((BrowserDetect.browser == "Camino") && (BrowserDetect.version >= 1)) ||
              (BrowserDetect.browser == "Mozilla")) {
        engine = "svg";
    }
    //engine = "wz";
    this.setfgcolor = new Function('arg', 'this.fgcolor = arg.toLowerCase();');
    this.setbgcolor = new Function('arg', 'this.bgcolor = arg.toLowerCase();');
    this.setbgopacity = new Function('arg', 'this.bgopacity = arg;');
    this.setlinewidth = new Function('arg', 'this.linewidth = arg;');
    this.setopacity = new Function('arg', 'this.opacity = arg;');

    this.setfgcolor("none");
    this.setbgcolor("");
    this.setlinewidth(1);
    this.setopacity(1);
    this.setbgopacity(1);

    this.linehandler = "";
    this.lineobject = "";


    //----------- set color in shape
    this.setFillColorWithOpacity = function(color, opc) {
        if (color) {
            this.setbgcolor(color);
        }
        if (opc) {
            this.setopacity(opc);
        }
    };

    this.setLineHandler = function(lineobject, handler) {
        if (handler) {
            this.linehandler = handler;
            this.lineobject = lineobject;
        }
    }
    //---------------------------

    this.setHeight = function(h) {
        if (h) {
            if (renderer) {
                if (engine == 'svg') {
                    renderer.svgRoot.setAttribute('height', h);
                }
                renderer.container.style.height = h;
            }
        }
    };

    this.setWidth = function(w) {
        if (w && renderer && renderer.container && renderer.container.style) {
            if (engine == 'svg') {
                renderer.svgRoot.setAttribute('width', w);
            }
            renderer.container.style.width = w;
        }
    };

    if ((engine == "svg") || (engine == "vml")) {
        if (engine == "svg") {
            var renderer = new SVGRenderer();
        } else {
            var renderer = new VMLRenderer();
        }

        renderer.init(cnv);

        this.drawEllipse = function(x1, y1, w, h, lineobject) {
            return renderer.create('ellipse', this.bgcolor, this.fgcolor, this.linewidth, x1, y1, w, h, this.opacity, this.bgopacity, lineobject);
        };

        this.drawLine = function(x1, y1, x2, y2) {
            return renderer.create('line', this.fillcolor, this.fgcolor, this.linewidth, x1, y1, x2 - x1, y2 - y1, this.opacity);
        };

        this.drawRect = function(x1, y1, w, h) {
            return renderer.create('rect', this.bgcolor, this.fgcolor, this.linewidth, x1, y1, w, h, this.opacity);
        };

        this.drawRoundrect = function(x1, y1, w, h) {
            return renderer.create('roundrect', this.bgcolor, this.fgcolor, this.linewidth, x1, y1, w, h, this.opacity);
        };

        this.clear = function() {
            renderer.container.innerHTML = "";
            if (engine == "svg") {
                var svgNamespace = 'http://www.w3.org/2000/svg';
                renderer.svgRoot = renderer.container.ownerDocument.createElementNS(svgNamespace, "svg");
                renderer.svgRoot.setAttribute('height', renderer.container.offsetHeight);
                renderer.svgRoot.setAttribute('width', renderer.container.offsetWidth);
                renderer.container.appendChild(renderer.svgRoot);
            }
        };

        this.createpoly = function(points, lineobject) {
            if (points.length) {
                this.lineobject = lineobject;
                return renderer.createpoly(this.bgcolor, this.fgcolor, this.linewidth, points, this.opacity, this.bgopacity, this.lineobject, this.linehandler);
            }
            else {
                return null;
            }
        }

        this.editCommand = function(shape, cmd, value) {
            renderer.editCommand(shape, cmd, value);
        }

        this.remove = function(id) {
            renderer.remove(id);
        };

        this.update = function() { };

    } else if (engine == "wz") {
        var jg_obj = new jsGraphics(cnv.id);
        jg_obj.setColor("#00ff00");
        this.drawEllipse = function(x1, y1, w, h) {
            if (this.bgcolor != "none") {
                jg_obj.setColor(this.bgcolor);
                jg_obj.fillEllipse(x1, y1, w, h);
            }
            if (this.fgcolor != "none") {
                jg_obj.setColor(this.fgcolor);
                jg_obj.setStroke(this.linewidth);
                jg_obj.drawEllipse(x1, y1, w - this.linewidth, h - this.linewidth);
            }
        };

        this.drawLine = function(x1, y1, x2, y2) {
            if (this.fgcolor != "none") {
                jg_obj.setColor(this.fgcolor);
                jg_obj.setStroke(this.linewidth);
                jg_obj.drawLine(x1, y1, x2, y2);
            }
        };

        this.drawRect = function(x1, y1, w, h) {
            if (this.bgcolor != "none") {
                jg_obj.setColor(this.bgcolor);
                jg_obj.fillRect(x1, y1, w, h);
            }
            if (this.fgcolor != "none") {
                jg_obj.setColor(this.fgcolor);
                jg_obj.setStroke(this.linewidth);
                jg_obj.drawRect(x1, y1, w - this.linewidth, h - this.linewidth);
            }
        };

        this.createpoly = function(points) {

            if (this.fgcolor != "none") {
                jg_obj.setColor(this.fgcolor);
                jg_obj.setStroke(this.linewidth);
                xp = new Array();
                yp = new Array();
                for (i = 0; i < points.length; i++) {
                    xp[i] = points[i][0];
                    yp[i] = points[i][1];
                }
                jg_obj.drawPolyline(xp, yp);
            }
        }

        this.drawRoundrect = function(x1, y1, x2, y2) {
            // to do
        };

        this.clear = function() {
            jg_obj.clear();
        }

        this.remove = function(id) {
        };

        this.update = function() { jg_obj.paint(); };

    }

}
// ---- BEGIN -- json lib

var jsonreqcnt = 0;
var jsonparent;
var jsononreq = function() { };
var jsononclear = function() { };
var jsonreqpendding = 0;
var jsonreqnode = [];
var jsontimeoutcounter = 0;

function json_check_timeout() {
    var ctime = new Date();
    var i;
    var s;

    for (i in jsonreqnode) {
        if (ctime - jsonreqnode[i].reqtime > 10000) {

            if (jsonreqnode[i].parentNode != null) {
                s = document.createElement('script');
                s.setAttribute('src', jsonreqnode[i].src);
                s.setAttribute('type', "text/javascript");
                s.reqtime = new Date();

                jsonparent.removeChild(jsonreqnode[i]);
                delete jsonreqnode[i];
                jsonparent.appendChild(s);
                jsonreqnode[i] = s;

                jsontimeoutcounter++;
            }
        }
    }

    setTimeout("json_check_timeout()", 10000);
}

function json_init(obj) {
    jsonparent = obj;
    //json_check_timeout();
}

function json_request(url, param, rvar, callback) {
    jsonreqpendding++;

    jsononreq();
    jsonreqcnt++;
    if (typeof (url) == 'undefined')
        alert(url + ' ' + param + ' ' + rvar + ' ' + callback);

    s = document.createElement('script');
    //	s.setAttribute('src', url + "?" + param + "&var=" + rvar + "&callback=" + callback + "&rand="+Math.random());
    s.setAttribute('src', url + "?" + param + "&var=" + rvar + "&callback=json_clear(" + jsonreqcnt + ");" + callback + "&rand=" + Math.random());
    s.setAttribute('type', "text/javascript");
    //	s.setAttribute('onload', "json_clear(" + jsonreqcnt + ");");
    //s.
    s.reqtime = new Date();
    jsonreqnode[jsonreqcnt] = s;
    jsonparent.appendChild(s);
}

function json_clear(nid) {
    //	if (jsonreqnode[nid]) {
    jsonreqpendding--;
    jsononclear();
    jsonparent.removeChild(jsonreqnode[nid]);
    delete jsonreqnode[nid];
    //jsonreqnode[nid] = false;
    //	}
}

function json_attach(onreq, onclear) {
    jsononreq = onreq;
    jsononclear = onclear;
}

// ---- END -- json lib
/**
* A class to parse color values
* @author Stoyan Stefanov <sstoo@gmail.com>
* @link   http://www.phpied.com/rgb-color-parser-in-javascript/
* @license Use it if you like it
*/
function RGBColor(color_string) {
    this.ok = false;

    // strip any leading #
    if (color_string.charAt(0) == '#') { // remove # if any
        color_string = color_string.substr(1, 6);
    }

    color_string = color_string.replace(/ /g, '');
    color_string = color_string.toLowerCase();

    // before getting into regexps, try simple matches
    // and overwrite the input
    var simple_colors = {
        aliceblue: 'f0f8ff',
        antiquewhite: 'faebd7',
        aqua: '00ffff',
        aquamarine: '7fffd4',
        azure: 'f0ffff',
        beige: 'f5f5dc',
        bisque: 'ffe4c4',
        black: '000000',
        blanchedalmond: 'ffebcd',
        blue: '0000ff',
        blueviolet: '8a2be2',
        brown: 'a52a2a',
        burlywood: 'deb887',
        cadetblue: '5f9ea0',
        chartreuse: '7fff00',
        chocolate: 'd2691e',
        coral: 'ff7f50',
        cornflowerblue: '6495ed',
        cornsilk: 'fff8dc',
        crimson: 'dc143c',
        cyan: '00ffff',
        darkblue: '00008b',
        darkcyan: '008b8b',
        darkgoldenrod: 'b8860b',
        darkgray: 'a9a9a9',
        darkgreen: '006400',
        darkkhaki: 'bdb76b',
        darkmagenta: '8b008b',
        darkolivegreen: '556b2f',
        darkorange: 'ff8c00',
        darkorchid: '9932cc',
        darkred: '8b0000',
        darksalmon: 'e9967a',
        darkseagreen: '8fbc8f',
        darkslateblue: '483d8b',
        darkslategray: '2f4f4f',
        darkturquoise: '00ced1',
        darkviolet: '9400d3',
        deeppink: 'ff1493',
        deepskyblue: '00bfff',
        dimgray: '696969',
        dodgerblue: '1e90ff',
        feldspar: 'd19275',
        firebrick: 'b22222',
        floralwhite: 'fffaf0',
        forestgreen: '228b22',
        fuchsia: 'ff00ff',
        gainsboro: 'dcdcdc',
        ghostwhite: 'f8f8ff',
        gold: 'ffd700',
        goldenrod: 'daa520',
        gray: '808080',
        green: '008000',
        greenyellow: 'adff2f',
        honeydew: 'f0fff0',
        hotpink: 'ff69b4',
        indianred: 'cd5c5c',
        indigo: '4b0082',
        ivory: 'fffff0',
        khaki: 'f0e68c',
        lavender: 'e6e6fa',
        lavenderblush: 'fff0f5',
        lawngreen: '7cfc00',
        lemonchiffon: 'fffacd',
        lightblue: 'add8e6',
        lightcoral: 'f08080',
        lightcyan: 'e0ffff',
        lightgoldenrodyellow: 'fafad2',
        lightgrey: 'd3d3d3',
        lightgreen: '90ee90',
        lightpink: 'ffb6c1',
        lightsalmon: 'ffa07a',
        lightseagreen: '20b2aa',
        lightskyblue: '87cefa',
        lightslateblue: '8470ff',
        lightslategray: '778899',
        lightsteelblue: 'b0c4de',
        lightyellow: 'ffffe0',
        lime: '00ff00',
        limegreen: '32cd32',
        linen: 'faf0e6',
        magenta: 'ff00ff',
        maroon: '800000',
        mediumaquamarine: '66cdaa',
        mediumblue: '0000cd',
        mediumorchid: 'ba55d3',
        mediumpurple: '9370d8',
        mediumseagreen: '3cb371',
        mediumslateblue: '7b68ee',
        mediumspringgreen: '00fa9a',
        mediumturquoise: '48d1cc',
        mediumvioletred: 'c71585',
        midnightblue: '191970',
        mintcream: 'f5fffa',
        mistyrose: 'ffe4e1',
        moccasin: 'ffe4b5',
        navajowhite: 'ffdead',
        navy: '000080',
        oldlace: 'fdf5e6',
        olive: '808000',
        olivedrab: '6b8e23',
        orange: 'ffa500',
        orangered: 'ff4500',
        orchid: 'da70d6',
        palegoldenrod: 'eee8aa',
        palegreen: '98fb98',
        paleturquoise: 'afeeee',
        palevioletred: 'd87093',
        papayawhip: 'ffefd5',
        peachpuff: 'ffdab9',
        peru: 'cd853f',
        pink: 'ffc0cb',
        plum: 'dda0dd',
        powderblue: 'b0e0e6',
        purple: '800080',
        red: 'ff0000',
        rosybrown: 'bc8f8f',
        royalblue: '4169e1',
        saddlebrown: '8b4513',
        salmon: 'fa8072',
        sandybrown: 'f4a460',
        seagreen: '2e8b57',
        seashell: 'fff5ee',
        sienna: 'a0522d',
        silver: 'c0c0c0',
        skyblue: '87ceeb',
        slateblue: '6a5acd',
        slategray: '708090',
        snow: 'fffafa',
        springgreen: '00ff7f',
        steelblue: '4682b4',
        tan: 'd2b48c',
        teal: '008080',
        thistle: 'd8bfd8',
        tomato: 'ff6347',
        turquoise: '40e0d0',
        violet: 'ee82ee',
        violetred: 'd02090',
        wheat: 'f5deb3',
        white: 'ffffff',
        whitesmoke: 'f5f5f5',
        yellow: 'ffff00',
        yellowgreen: '9acd32'
    };
    for (var key in simple_colors) {
        if (color_string == key) {
            color_string = simple_colors[key];
        }
    }
    // emd of simple type-in colors

    // array of color definition objects
    var color_defs = [
        {
            re: /^rgb\((\d{1,3}),\s*(\d{1,3}),\s*(\d{1,3})\)$/,
            example: ['rgb(123, 234, 45)', 'rgb(255,234,245)'],
            process: function(bits) {
                return [
                    parseInt(bits[1]),
                    parseInt(bits[2]),
                    parseInt(bits[3])
                ];
            }
        },
        {
            re: /^(\w{2})(\w{2})(\w{2})$/,
            example: ['#00ff00', '336699'],
            process: function(bits) {
                return [
                    parseInt(bits[1], 16),
                    parseInt(bits[2], 16),
                    parseInt(bits[3], 16)
                ];
            }
        },
        {
            re: /^(\w{1})(\w{1})(\w{1})$/,
            example: ['#fb0', 'f0f'],
            process: function(bits) {
                return [
                    parseInt(bits[1] + bits[1], 16),
                    parseInt(bits[2] + bits[2], 16),
                    parseInt(bits[3] + bits[3], 16)
                ];
            }
        }
    ];

    // search through the definitions to find a match
    for (var i = 0; i < color_defs.length; i++) {
        var re = color_defs[i].re;
        var processor = color_defs[i].process;
        var bits = re.exec(color_string);
        if (bits) {
            channels = processor(bits);
            this.r = channels[0];
            this.g = channels[1];
            this.b = channels[2];
            this.ok = true;
        }

    }

    // validate/cleanup values
    this.r = (this.r < 0 || isNaN(this.r)) ? 0 : ((this.r > 255) ? 255 : this.r);
    this.g = (this.g < 0 || isNaN(this.g)) ? 0 : ((this.g > 255) ? 255 : this.g);
    this.b = (this.b < 0 || isNaN(this.b)) ? 0 : ((this.b > 255) ? 255 : this.b);

    // some getters
    this.toRGB = function() {
        return 'rgb(' + this.r + ', ' + this.g + ', ' + this.b + ')';
    }
    this.toHex = function() {
        var r = this.r.toString(16);
        var g = this.g.toString(16);
        var b = this.b.toString(16);
        if (r.length == 1) r = '0' + r;
        if (g.length == 1) g = '0' + g;
        if (b.length == 1) b = '0' + b;
        return '#' + r + g + b;
    }

    // help
    this.getHelpXML = function() {

        var examples = new Array();
        // add regexps
        for (var i = 0; i < color_defs.length; i++) {
            var example = color_defs[i].example;
            for (var j = 0; j < example.length; j++) {
                examples[examples.length] = example[j];
            }
        }
        // add type-in colors
        for (var sc in simple_colors) {
            examples[examples.length] = sc;
        }

        var xml = document.createElement('ul');
        xml.setAttribute('id', 'rgbcolor-examples');
        for (var i = 0; i < examples.length; i++) {
            try {
                var list_item = document.createElement('li');
                var list_color = new RGBColor(examples[i]);
                var example_div = document.createElement('div');
                example_div.style.cssText =
                        'margin: 3px; '
                        + 'border: 1px solid black; '
                        + 'background:' + list_color.toHex() + '; '
                        + 'color:' + list_color.toHex()
                ;
                example_div.appendChild(document.createTextNode('test'));
                var list_item_value = document.createTextNode(
                    ' ' + examples[i] + ' -> ' + list_color.toRGB() + ' -> ' + list_color.toHex()
                );
                list_item.appendChild(example_div);
                list_item.appendChild(list_item_value);
                xml.appendChild(list_item);

            } catch (e) { }
        }
        return xml;

    }

}

// ---- BEGIN -- Search
var search_keyword = "";
var searchdiv = new Array();
var search_shape = new Array();
var searchresultdiv;

var mmmapurl = "http://mmmap15.longdo.com//mmmap";

function addslashes(str) {
    str = str.replace(/\\/g, '\\\\');
    str = str.replace(/\'/g, '\\\'');
    str = str.replace(/\"/g, '\\"');
    str = str.replace(/\0/g, '\\0');
    return str;
}

function clearsearchpopupdiv() {
    for (i = 0; i < searchdiv.length; i++) {
        mmmap.removeCustomDivs(searchdiv[i]);
    }
    searchdiv = new Array();
}

function gensearchpopup(obj) {
    return obj.name + "<br>" + obj.name_en
}

function removesearchshape() {
    for (var i = 0; i < search_shape.length; i++) {
        mmmap.removeVector(search_shape[i]);
    }
    search_shape = new Array();
}

function clearsearch() {
    clearsearchpopupdiv();
    removesearchshape();
    searchresultdiv.innerHTML = "";
}

function do_search(offset, word, ddiv) {
    if (offset == null) offset = 0;
    if (word != null)
        search_keyword = word;
    if (ddiv != null)
        searchresultdiv = document.getElementById(ddiv);

    clearsearchpopupdiv();

    if (!latitude) latitude = 13;
    if (!longitude) longitude = 100;

    text = "<br><div align=\"center\"><img src=\"" + mmmapurl + "/images/loading.gif\"></div>";
    searchresultdiv.innerHTML = text;
    json_request(mmmapurl + "/../search/rpc-json.php", "map=msn1&search=" + search_keyword + "&bookmark=" + offset + "&center_lat=" + latitude + "&center_long=" + longitude + "&action=search&mode=json&key=d9c8884535ae82504c4962ce47a4cae4", "sresult", "getsearch();");
}

function searchitemclick(lat, lng, zoom, title, detail, fly) {
    if (fly) {
        //mmmap.setRes(Math.pow(2,zoom));
        mmmap.setZoom(zoom);
        mmmap.moveTo(lat, lng);
    }
    mmmap.showPopUp(lat, lng, title, detail);
}

function getsearch() {
    r = sresult.data;
    m = sresult.meta;

    keyword = m.keyword;

    minzoom = 20;
    minlat = -1;
    minlong = -1;
    bgc = ["#feffd1", "#ffffff"];
    bgcr = ["#ffd9d9", "#ffefdc"];
    bgck = ["#dbffdb", "#c0ffc0"];
    bgct = ["#ffddb5", "#ffefdc"];

    if (r.length > 0)
        text = "ผลลัพธ์รายการที่ " + (m.start + 1) + " - " + (m.end + 1) + "&nbsp;&nbsp;&nbsp;<a href='javascript: clearsearch();'>[ลบ]</a><br><br>";
    else
        text = "ไม่พบข้อมูลใดๆ ที่เกี่ยวข้อง";

    text += "<table cellpadding=0 cellspacing=0>";
    for (i = 0; i < r.length; i++) {
        if (r[i].objecttype == "poi") {
            text += "<tr class='mmmap_search_result' style='font-size: 10pt;background-color:" + bgc[i % 2] + "'><td valign=top>" + (m.start + 1 + i) + ".&nbsp;</td><td valign=top>";
            text += "<a href=\"javascript: ;\" onclick=\"searchitemclick(" + r[i].lat + "," + r[i].lng + "," + r[i].showlevel + ",'" + r[i].name + "','" + addslashes(gensearchpopup(r[i])) + "')\">" + r[i].name + "</a>"
					 + " [<a href=\"javascript: ;\" onclick=\"searchitemclick(" + r[i].lat + "," + r[i].lng + "," + r[i].showlevel + ",'" + r[i].name + "','" + addslashes(gensearchpopup(r[i])) + "', true)\">+</a>]";
            var smark = document.createElement("div");
            smark.innerHTML = "<img src=\"" + mmmapurl + "/images/red-dot.gif\">";
            searchdiv[searchdiv.length] = mmmap.drawCustomDivLevelWithPopup(smark, r[i].lat, r[i].lng, r[i].name, /* r[i].showlevel */3, 14, gensearchpopup(r[i]));
            if (r[i].showlevel < minzoom) {
                minzoom = r[i].showlevel;
                minlat = r[i].lat;
                minlong = r[i].lng;
            }
        } else if ((r[i].objecttype == "road")) {
            text += "<tr class='mmmap_search_result' style='font-size: 10pt;background-color:" + bgcr[i % 2] + "'><td valign=top>" + (m.start + 1 + i) + ".&nbsp;</td><td valign=top>";
            text += "<a href=\"javascript: ;\" onclick=\"mmmap.moveTo('" + r[i].lat + "', '" + r[i].lng + "');mmmap.showPopUp('" + r[i].lat + "', '" + r[i].lng + "', '" + r[i].name + "', '" + gensearchpopup(r[i]) + "');\">" + r[i].name + "</a>";

        } else if ((r[i].objecttype == "khet")) {
            text += "<tr class='mmmap_search_result' style='font-size: 10pt;background-color:" + bgck[i % 2] + "'><td valign=top>" + (m.start + 1 + i) + ".&nbsp;</td><td valign=top>";
            text += "<a href=\"javascript: ;\" onclick=\"mmmap.moveTo('" + r[i].lat + "', '" + r[i].lng + "');mmmap.showPopUp('" + r[i].lat + "', '" + r[i].lng + "', '" + r[i].name + "', '" + gensearchpopup(r[i]) + "');\">" + r[i].name + "</a>";

        } else if ((r[i].objecttype == "tag")) {
            text += "<tr class='mmmap_search_result' style='font-size: 10pt;background-color:" + bgct[i % 2] + "'><td valign=top>" + (m.start + 1 + i) + ".&nbsp;</td><td valign=top>";
            var mytag = r[i].name.replace(/^tag:\s/, "");
            text += "<a href=\"javascript: ;\" onclick=\"mmmap.showOOITagWithShowLevel('" + mytag + "', 3, 15, 12, 15);\">" + r[i].name + "</a>";

        } else {
            text += (m.start + 1 + i) + ".&nbsp; " + r[i].name + "<br>";
        }
        text += "</td></tr>";
    }

    text += "</tr></table><table width=95%><tr class='mmmap_search_result' style='font-size: 10pt'>";

    if (m.start > 0) {
        text += '<td align=left><a title="Back" style="text-decoration: none" href="javascript: ;" onclick="do_search(' + ((m.start > 20) ? (m.start - 20) : 0) + ');">&lt;&lt;</a></td> ';
    }
    if (m.hasmore == true) {
        text += '<td align=right><a title="More" style="text-decoration: none" href="javascript: ;" onclick="do_search(' + (m.start + 20) + ');">&gt;&gt;</a></td>';
    }

    text += "</tr></table>";

    if (minlat != -1) {
        mmmap.moveTo(minlat, minlong);
    }

    searchresultdiv.innerHTML = text;
}

// ... SUB BEGIN ... road

function loadroad(roadname, node, khet) {
    id = Math.round(Math.random() * 1000);

    loading = document.createElement("span");
    loading.innerHTML = " <img style=\"vertical-align: middle;\" src=\"" + mmmapurl + "/images/loading_bar.gif\" border='0'>";
    loading.id = "showroadload_" + id;
    node.loading_img = loading;
    node.appendChild(loading);

    if ((khet != null) && (khet == true)) {
        vname = "khetname";
        act = "showkhet";
    } else {
        vname = "roadname";
        act = "showroad";
    }

    json_request("http://mmmap15.longdo.com/search/rpc-json.php", "map=msn1&" + vname + "=" + roadname + "&action=" + act + "&mode=json&key=d9c8884535ae82504c4962ce47a4cae4", "srresult", "showroad(" + id + ");");
}

function showroad(nid) {
    r = srresult.data;
    m = srresult.meta;

    // remove the loading image
    l = document.getElementById("showroadload_" + nid);
    l.parentNode.removeChild(l);
    startpoint = false;

    polyline = new Array();
    removesearchshape();
    for (i = 0; i < r.length; i++) {

        if (startpoint == false)
            startpoint = [r[i].lng, r[i].lat];

        polyline[polyline.length] = [r[i].lng, r[i].lat, r[i].ring];
    }

    if (polyline.length > 0) {
        search_shape[search_shape.length] = mmmap.drawPolyline(polyline, 4, 14, m.resultname, m.resultname_en);
    }

    if (startpoint != false) {
        mmmap.moveTo(startpoint[1], startpoint[0]);
        mmmap.showPopUp(r[0].lat, r[0].lng, m.resultname, m.resultname + "<br>" + m.resultname_en);
    }

}

// ... SUB END ... road


// ---- END -- Search
MMMap.prototype.receivePOIsResult_timer = null;

MMMap.prototype.receivePOIsResult = function() {
    var mymeta = poisresult.meta;
    var mydata = poisresult.data;

    var imgid = mymeta.imgid;
    var dispimg = mymeta.dispimg;
    var zoom = mymeta.zoom;

    var n_pois = mydata.length;

    if (n_pois == 0) {
        return;
    }

    poi_saved[zoom][imgid] = new Array();
    poi_num[zoom][imgid] = n_pois;

    for (var i = 0; i < n_pois; i++) {

        var item = mydata[i];

        var id = item.id;
        var name = item.name;
        var lat = item.lat;
        var mylong = item.lng;
        var type = item.type;
        var status = item.status;
        var showlevel = item.showlevel;
        var name_en = item.name_en;
        var contributor = item.contributor;
        var imagefile = item.imagefile;
        var iconlabel = item.iconlabel;
        var iconlabel_en = item.iconlabel_en;
        //alert(id+","+name+","+lat+","+mylong+","+zoom+", "+imgid + ", " + dispimg+", "+ showlevel + ", " +i);

        // save to poi array
        poi_saved[zoom][imgid][i] = new Array();

        var usename = name;

        if (mylang == "en") {
            usename = name_en;

            if (name_en == "") {
                usename = "(Thai) " + name;
            }
        }

        var useiconlabel = iconlabel;
        if (mylang == "en") {
            useiconlabel = iconlabel_en;
        }

        poi_saved[zoom][imgid][i][0] = id;
        poi_saved[zoom][imgid][i][1] = usename;
        poi_saved[zoom][imgid][i][2] = lat;
        poi_saved[zoom][imgid][i][3] = mylong;
        poi_saved[zoom][imgid][i][4] = status;
        poi_saved[zoom][imgid][i][5] = contributor;
        poi_saved[zoom][imgid][i][6] = imagefile;
        poi_saved[zoom][imgid][i][7] = useiconlabel;
    }

    drawPOIFromArray(zoom, imgid, dispimg);

    var oldnum = poi_images_num[dispimg];
    if (n_pois < oldnum) {
        for (var i = n_pois; i < oldnum; i++) {
            mymap.removeChild(poi_images[dispimg][i]);

            if (poi_images_label[dispimg][i]) {
                mymap.removeChild(poi_images_label[dispimg][i]);
            }
        }
    }
    poi_images_num[dispimg] = n_pois;
}
MMMap.prototype.RulerToolbar = function RulerToolbar(mmmap) {
    this.mm_numline = 0;
    this.line = [];
    this.mmmap = mmmap;
    this.rulertoolbar = false;
    this.linecolor = ['#FE00FF', '#1FBC00', '#950000'];
    this.numc = 0;
    this.hasline = false;

    this.newLine = function newLine() {
        this.line[this.mm_numline] = new MMLine(this.mmmap, 1);
        this.line[this.mm_numline].setRulerButtonFn(this.changeRulerButton);
        this.line[this.mm_numline].setColor(this.linecolor[this.numc]);
        this.line[this.mm_numline].setThickness(5);
        this.numc++;
        if (this.numc > this.linecolor.length - 1) this.numc = 0;
        this.line[this.mm_numline].setListenToEvents(true);
        this.mm_numline++;
    }

    this.clearAllLine = function clearAllLine() {
        for (var i = 0; i < this.rulerbutton.mm_numline; i++) {
            this.rulerbutton.line[i].clearLine();
        }
        this.rulerbutton.hasline = false;
        document.getElementById('mm-ruler-del-button').style.display = 'none';
        document.getElementById('mm-ruler-del-button-off').style.display = 'inline';
    }

    this.initRulerToolbar = function initRulerToolbar() {
        var toolbar = document.createElement('div');
        var mapdiv = this.mmmap.getMapDiv();
        toolbar.innerHTML = '<div id="mm-ruler-toolbar" style="position:absolute; left:' + this.mleft + 'px; top:' + this.mtop + 'px; width:200px; height:24px;z-index:5000; font-size:11px; display:none;"></div>';
        document.getElementsByTagName("body")[0].appendChild(toolbar);
        var s1 = document.createElement('script');
        s1.src = 'http://' + this.mmmap.servername + '/mmmap/js/mmline.js';
        var loaded = false;
        s1.onload = s1.onreadystatechange = function() {
            var rs = this.readyState;
            if (rs && rs != 'complete' && rs != 'loaded') return;
            if (loaded) return;
            loaded = true;
            setTimeout("document.getElementById('mm-ruler-toolbar').style.display = 'inline'", 1500);
        };
        document.getElementsByTagName("head")[0].appendChild(s1);
    }

    this.buttonisclick = false;
    this.fn = '';
    this.changeRulerButton = function rulerButton() {
        var rulerbutton = document.getElementById("mm-ruler-new-button").rulerbutton;
        if (rulerbutton.buttonisclick) {
            //alert(this.hasline);
            if (!rulerbutton.hasline) rulerbutton.hasline = this.hasline;
            if (document.getElementById("mm-ruler-off")) document.getElementById("mm-ruler-off").style.display = 'inline';
            if (document.getElementById("mm-ruler-on")) document.getElementById("mm-ruler-on").style.display = 'none';
            if (document.getElementById("mm-ruler-new-button")) document.getElementById('mm-ruler-new-button').onclick = rulerbutton.fn;
            rulerbutton.buttonisclick = false;
            if (document.getElementById("mm-ruler-del-button") && rulerbutton.hasline) {
                document.getElementById('mm-ruler-del-button').style.display = 'inline';
                if (document.getElementById("mm-ruler-del-button-off")) document.getElementById('mm-ruler-del-button-off').style.display = 'none';
            }
        }
        else {
            if (document.getElementById("mm-ruler-off")) document.getElementById("mm-ruler-off").style.display = 'none';
            if (document.getElementById("mm-ruler-on")) {
                document.getElementById("mm-ruler-on").style.display = 'inline';
            }
            if (document.getElementById("mm-ruler-new-button")) rulerbutton.fn = document.getElementById('mm-ruler-new-button').onclick;
            if (document.getElementById("mm-ruler-new-button")) document.getElementById('mm-ruler-new-button').onclick = rulerbutton.stopLine;
            rulerbutton.buttonisclick = true;
            if (document.getElementById("mm-ruler-del-button")) document.getElementById('mm-ruler-del-button').style.display = 'none';
            if (document.getElementById("mm-ruler-del-button-off")) document.getElementById('mm-ruler-del-button-off').style.display = 'inline';
            rulerbutton.newLine();
        }
    }

    this.stopLine = function() {
        this.rulerbutton.line[this.rulerbutton.mm_numline - 1].setListenToEvents(false);
        document.getElementById('mm-ruler-new-button').onclick = this.rulerbutton.changeRulerButton;
    }

    this.initButtons = function() {
        if (document.getElementById("mm-ruler-new-button")) {
            document.getElementById("mm-ruler-new-button").onclick = this.changeRulerButton;
            document.getElementById("mm-ruler-new-button").rulerbutton = this;
        }
        if (document.getElementById("mm-ruler-del-button")) {
            document.getElementById("mm-ruler-del-button").onclick = this.clearAllLine;
            document.getElementById("mm-ruler-del-button").rulerbutton = this;
        }
    }

    this.setControlPosition = function(left, top) {
        var toolbar = document.getElementById('mm-ruler-toolbar');
        toolbar.style.left = left + 'px';
        toolbar.style.top = top + 'px';
    }

    this.addButtons = function(buttons) {
        if (typeof (buttons) == 'array') {
            for (var i = 0; i < buttons.length; i++) {
                switch (buttons[i]) {
                    case 'measure':
                        var b1 = document.createElement('span');
                        b1.id = 'mm-ruler-new-button';
                        b1.style.cursor = 'pointer';
                        b1.innerHTML = '<img id="mm-ruler-off" src="http://mmmap15.longdo.com//mmmap/images/line.png" title="Measure distance" style="display:inline;"><img id="mm-ruler-on" src="http://mmmap15.longdo.com//mmmap/images/line2.png" title="New line" style="display:none;" title="Click to finish the line.">';
                        document.getElementById("mm-ruler-toolbar").appendChild(b1);
                        break;
                    case 'clear':
                        var b1 = document.createElement('span');
                        b1.innerHTML = '<span id="mm-ruler-del-button" style="cursor:pointer; display:none;"><img src="http://mmmap15.longdo.com//mmmap/images/clear.png" title="Clear map" style=""></span><span id="mm-ruler-del-button-off" display:inline;><img id="mm-clear-off" src="http://mmmap15.longdo.com//mmmap/images/clear2.png"></span>';
                        document.getElementById("mm-ruler-toolbar").appendChild(b1);
                        break;
                }
            }
        }
        else if (typeof (buttons) == 'string') {
            switch (buttons) {
                case 'measure':
                    var b1 = document.createElement('span');
                    b1.id = 'mm-ruler-new-button';
                    b1.style.cursor = 'pointer';
                    b1.innerHTML = '<img id="mm-ruler-off" src="http://mmmap15.longdo.com//mmmap/images/line.png" title="Measure distance" style="display:inline;"><img id="mm-ruler-on" src="http://mmmap15.longdo.com//mmmap/images/line2.png" title="New line" style="display:none;" title="Click to finish the line.">';
                    document.getElementById("mm-ruler-toolbar").appendChild(b1);
                    break;
                case 'clear':
                    var b1 = document.createElement('span');
                    b1.innerHTML = '<span id="mm-ruler-del-button" style="cursor:pointer; display:none;"><img src="http://mmmap15.longdo.com//mmmap/images/clear.png" title="Clear map" style=""></span><span id="mm-ruler-del-button-off" display:inline;><img id="mm-clear-off" src="http://mmmap15.longdo.com//mmmap/images/clear2.png"></span>';
                    document.getElementById("mm-ruler-toolbar").appendChild(b1);
                    break;
            }
        }
        this.initButtons();
    }

    this.getWhere = function(who) {

        var T = 0, L = 0;
        while (who != null) {
            //alert(who);
            if (who.offsetWidth != undefined) {
                L += parseInt(who.offsetLeft);
                //L = who.offsetWidth - 300;
                T += parseInt(who.offsetTop);
                who = who.offsetParent;
            }
        }
        return { 'left': L, 'top': T };
    }

    this.rePaint = function() {
        var lt = this.getWhere(this.mmmap.getMapDiv());

        this.mtop = lt.top + 5;
        this.mleft = lt.left + 5;
        var toolbar = document.getElementById("mm-ruler-toolbar");
        var leftbefore = toolbar.style.left;
        var topbefore = toolbar.style.top;
        toolbar.style.left = this.mleft + 'px';
        toolbar.style.top = this.mtop + 'px';
        //alert(leftbefore+':'+topbefore+'\n'+toolbar.style.left+':'+toolbar.style.top);
    }

    this.setVisibility = function(bool) {
        var toolbar = document.getElementById("mm-ruler-toolbar");
        if (bool) {
            toolbar.style.visibility = "visible";
        }
        else if (!bool) {
            toolbar.style.visibility = "hidden";
        }
    }

    this.lt = this.getWhere(this.mmmap.getMapDiv());
    this.mtop = this.lt.top + 5; //parseInt(this.mmmap.getMapDiv().offsetTop)+parseInt(this.mmmap.getMapDiv().offsetParent.offsetTop)+5;
    this.mleft = this.lt.left + 5; //parseInt(this.mmmap.getMapDiv().offsetLeft)+parseInt(this.mmmap.getMapDiv().offsetParent.offsetLeft)+5;
    //alert(this.getWhere(this.mmmap.getMapDiv()));
}

function MMCanvas(mapobj) {
    document.MMCanvas = this;
    this.drawing = false;
    this.numpolygon = 1;
    this.mmmap = mapobj;
    this.saveURL = '';
    this.colorindex = 0;
    this.addshapecallback = false;
    this.delshapecallback = false;
    this.color = ['#FE00FF', '#1FBC00', '#950000', '#2F6C7F', '#FF831F', '#452FFF']; // define color here
    document.canvasenable = 1;
    ie = navigator.appVersion.match(/MSIE (\d\.\d)/);
    opera = (navigator.userAgent.toLowerCase().indexOf("opera") != -1);
    if ((!ie) || (opera)) {
        this.renderer = new SVGRenderer();
    }
    else {
        this.renderer = new VMLRenderer();
    }

    this.canvas = document.getElementById("_mmmap_vector_div");
    this.shapes = new Array();
    this.numshapes = 0;
    //styles
    this.canvas_line_color = '#31829F';
    this.canvas_fill_color = '#31829F';
    this.canvas_line_opac = '0.8';
    this.canvas_fill_opac = '0.6';
    if (ie) {
        this.canvas_line_width = 4;
    } else {
        this.canvas_line_width = 5;
    }

    var pallete = document.createElement("div");
    pallete.id = "MM-pallete";
    pallete.style.position = "absolute";
    pallete.style.display = "none";
    pallete.style.left = '0px';
    pallete.style.top = '0px';
    pallete.style.zIndex = '3000';
    pallete.innerHTML = this.getPalleteTable();
    pallete.onmouseout = function() { this.style.display = 'none'; }
    pallete.onmouseover = function() { this.style.display = 'block'; }
    document.body.appendChild(pallete);

    this.lt = this.getWhere(this.mmmap.getMapDiv());
    this.mtop = this.lt.top + 5;
    this.mleft = this.lt.left + 5;

    var toolbar = document.createElement('div');
    var mapdiv = this.mmmap.getMapDiv();
    toolbar.innerHTML = '<div id="mm-ruler-toolbar" style="position:absolute; left:' + this.mleft + 'px; top:' + this.mtop + 'px; width:200px; height:24px;z-index:5000; font-size:11px;"></div>';
    document.getElementsByTagName("body")[0].appendChild(toolbar);

}

MMCanvas.prototype.rePaint = function() {
    this.lt = this.getWhere(this.mmmap.getMapDiv());
    this.mtop = this.lt.top + 5;
    this.mleft = this.lt.left + 5;
    document.getElementById('mm-ruler-toolbar').style.left = this.mleft + "px";
    document.getElementById('mm-ruler-toolbar').style.top = this.mtop + "px";
}

MMCanvas.prototype.addShape = function(mode) {
    this.drawing = true;
    this.canvas_fill_color = this.color[this.colorindex];
    this.shapes[this.numshapes] = new MMLine(mmmap, mode, this);
    this.shapes[this.numshapes].setLineColor(this.color[this.colorindex]);
    this.shapes[this.numshapes].showEditPopup(true);
    this.shapes[this.numshapes].setSaveURL(this.saveURL);
    //this.shapes[this.numshapes].setID(this.numshapes);
    this.numpolygon++;
    this.shapes[this.numshapes].setListenToEvents(true);


    this.shapes[this.numshapes].setRulerButtonFn(this.changeRulerButton);
    this.numshapes++;

    this.colorindex++;
    if (this.colorindex > this.color.length - 1) this.colorindex = 0;
    if (this.addshapecallback) this.addshapecallback();
    return this.shapes[this.numshapes - 1];
};

MMCanvas.prototype.setSaveURL = function(url) {
    this.saveURL = url;
}

MMCanvas.prototype.clearWorkspace = function() {
    for (var i = 0; i < this.rulerbutton.numshapes; i++) {
        if (this.rulerbutton.shapes[i])
            this.rulerbutton.shapes[i].clearLine();
    }
    this.rulerbutton.numshapes = 0;
    this.rulerbutton.shapes = new Array();
    document.getElementById('mm-ruler-del-button').style.display = 'none';
    document.getElementById('mm-ruler-del-button-off').style.display = 'inline';
    this.rulerbutton.canvas.innerHTML = '';
};

MMCanvas.prototype.getPalleteTable = function() {
    palletetable = '<table cellspacing="0" cellpadding="0"><tbody><tr><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#ffffff" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-ffffff"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#cccccc" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-cccccc"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#c0c0c0" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-c0c0c0"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#999999" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-999999"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#666666" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-666666"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#333333" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-333333"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#000000" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-000000"><img height="1" width="1"/></td></tr><tr><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#ffcccc" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-ffcccc"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#ff6666" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-ff6666"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#ff0000" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-ff0000"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#cc0000" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-cc0000"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#990000" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-990000"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#660000" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-660000"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#330000" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-330000"><img height="1" width="1"/></td></tr><tr><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#ffcc99" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-ffcc99"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#ff9966" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-ff9966"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#ff9900" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-ff9900"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#ff6600" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-ff6600"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#cc6600" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-cc6600"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#993300" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-993300"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#663300" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-663300"><img height="1" width="1"/></td></tr><tr><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#ffff99" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-ffff99"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#ffff66" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-ffff66"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#ffcc66" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-ffcc66"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#ffcc33" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-ffcc33"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#cc9933" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-cc9933"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#996633" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-996633"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#663333" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-663333"><img height="1" width="1"/></td></tr><tr><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#ffffcc" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-ffffcc"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#ffff33" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-ffff33"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#ffff00" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-ffff00"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#ffcc00" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-ffcc00"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#999900" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-999900"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#666600" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-666600"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#333300" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-333300"><img height="1" width="1"/></td></tr><tr><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#99ff99" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-99ff99"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#66ff99" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-66ff99"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#33ff33" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-33ff33"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#33cc00" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-33cc00"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#009900" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-009900"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#006600" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-006600"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#003300" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-003300"><img height="1" width="1"/></td></tr><tr><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#99ffff" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-99ffff"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#33ffff" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-33ffff"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#66cccc" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-66cccc"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#00cccc" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-00cccc"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#339999" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-339999"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#336666" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-336666"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#003333" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-003333"><img height="1" width="1"/></td></tr><tr><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#ccffff" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-ccffff"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#66ffff" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-66ffff"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#33ccff" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-33ccff"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#3366ff" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-3366ff"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#3333ff" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-3333ff"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#000099" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-000099"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#000066" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-000066"><img height="1" width="1"/></td></tr><tr><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#ccccff" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-ccccff"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#9999ff" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-9999ff"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#6666cc" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-6666cc"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#6633ff" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-6633ff"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#6600cc" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-6600cc"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#333399" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-333399"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#330099" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-330099"><img height="1" width="1"/></td></tr><tr><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#ffccff" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-ffccff"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#ff99ff" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-ff99ff"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#cc66cc" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-cc66cc"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#cc33cc" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-cc33cc"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#993399" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-993399"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#663366" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-663366"><img height="1" width="1"/></td><td onclick="document.selectedShape.lineobject.setColor(this.id)" bgcolor="#330033" style="border: 1px solid #AFAFAF; margin: 0px; padding: 0px; width: 15px; height: 15px;" unselectable="on" id="color-330033"><img height="1" width="1"/></td></tr></tbody></table>';
    return palletetable;
};

MMCanvas.prototype.addButton = function(buttons) {
    if (typeof (buttons) == 'array') {
        for (var i = 0; i < buttons.length; i++) {
            switch (buttons[i]) {
                case 'measure':
                    var b1 = document.createElement('span');
                    b1.id = 'mm-ruler-new-button';
                    b1.style.cursor = 'pointer';
                    b1.innerHTML = '<img id="mm-ruler-off" src="http://mmmap15.longdo.com//mmmap/images/line.png" title="Measure distance" style="display:inline;"><img id="mm-ruler-on" src="http://mmmap15.longdo.com//mmmap/images/line2.png" title="New line" style="display:none;" title="Click to finish the line.">';
                    document.getElementById("mm-ruler-toolbar").appendChild(b1);
                    break;
                case 'clear':
                    var b1 = document.createElement('span');
                    b1.innerHTML = '<span id="mm-ruler-del-button" style="cursor:pointer; display:none;"><img src="http://mmmap15.longdo.com//mmmap/images/clear.png" title="Clear map" style=""></span><span id="mm-ruler-del-button-off" display:inline;><img id="mm-clear-off" src="http://mmmap15.longdo.com//mmmap/images/clear2.png"></span>';
                    document.getElementById("mm-ruler-toolbar").appendChild(b1);
                    break;
            }
        }
    }
    else if (typeof (buttons) == 'string') {
        switch (buttons) {
            case 'measure':
                var b1 = document.createElement('span');
                b1.id = 'mm-ruler-new-button';
                b1.style.cursor = 'pointer';
                b1.innerHTML = '<img id="mm-ruler-off" src="http://mmmap15.longdo.com//mmmap/images/line.png" title="Measure distance" style="display:inline;"><img id="mm-ruler-on" src="http://mmmap15.longdo.com//mmmap/images/line2.png" title="New line" style="display:none;" title="Click to finish the line.">';
                document.getElementById("mm-ruler-toolbar").appendChild(b1);
                break;
            case 'poly':
                var b1 = document.createElement('span');
                b1.id = 'mm-poly-new-button';
                b1.style.cursor = 'pointer';
                b1.innerHTML = '<img id="mm-poly-off" src="http://mmmap15.longdo.com//mmmap/images/poly.png" title="Create polyline" style="display:inline;"><img id="mm-poly-on" src="http://mmmap15.longdo.com//mmmap/images/poly2.png" title="New polyline" style="display:none;" title="Click to finish this shape.">';
                document.getElementById("mm-ruler-toolbar").appendChild(b1);
                break;
            case 'clear':
                var b1 = document.createElement('span');
                b1.innerHTML = '<span id="mm-ruler-del-button" style="cursor:pointer; display:none;"><img src="http://mmmap15.longdo.com//mmmap/images/clear.png" title="Clear map" style=""></span><span id="mm-ruler-del-button-off" display:inline;><img id="mm-clear-off" src="http://mmmap15.longdo.com//mmmap/images/clear2.png"></span>';
                document.getElementById("mm-ruler-toolbar").appendChild(b1);
                break;

            case 'load':
                var b1 = document.createElement('span');
                b1.innerHTML = '<span id="mm-load-button" style="cursor:pointer; display:inline;"><strong>Load</strong></span>';
                document.getElementById("mm-ruler-toolbar").appendChild(b1);
                break;
        }
    }
    this.initButtons();
}

MMCanvas.prototype.getWhere = function(who) {

    var T = 0, L = 0;
    while (who != null) {
        if (who.offsetWidth != undefined) {
            L += parseInt(who.offsetLeft);
            T += parseInt(who.offsetTop);
            who = who.offsetParent;
        }
    }
    return { 'left': L, 'top': T };
}

MMCanvas.prototype.initButtons = function() {
    if (document.getElementById("mm-ruler-new-button")) {
        document.getElementById("mm-ruler-new-button").onclick = this.changeRulerButton;
        document.getElementById("mm-ruler-new-button").rulerbutton = this;
    }
    if (document.getElementById("mm-poly-new-button")) {
        document.getElementById("mm-poly-new-button").onclick = this.changeRulerButton;
        document.getElementById("mm-poly-new-button").rulerbutton = this;
    }
    if (document.getElementById("mm-ruler-del-button")) {
        document.getElementById("mm-ruler-del-button").onclick = this.clearWorkspace;
        document.getElementById("mm-ruler-del-button").rulerbutton = this;
    }
    //test
    if (document.getElementById("mm-load-button")) {
        document.getElementById("mm-load-button").onclick = this.loadShape;
        document.getElementById("mm-load-button").canvas = this;
    }
}

MMCanvas.prototype.changeRulerButton = function rulerButton() {


    var rulerbutton = '';
    var id = '';
    //alert(this);
    if (typeof (this.rulerbutton) != 'undefined') {
        id = this.id.split("-");
        id = id[0] + '-' + id[1];
    }
    else {
        if (this.mode == 1) {
            id = 'mm-ruler';
        } else if (this.mode == 0) {
            id = 'mm-poly';
        }
    }
    var unclickbutton = '';
    if (id == 'mm-ruler') {
        unclickbutton = 'mm-poly';
    } else if (id == 'mm-poly') {
        unclickbutton = 'mm-ruler';
    }
    rulerbutton = document.getElementById(id + "-new-button").rulerbutton;
    rulerbutton.initButtons();
    if (rulerbutton.buttonisclick) {
        if (!rulerbutton.hasline) rulerbutton.hasline = this.hasline;
        if (document.getElementById(id + "-off")) document.getElementById(id + "-off").style.display = 'inline';
        if (document.getElementById(id + "-on")) document.getElementById(id + "-on").style.display = 'none';
        if (document.getElementById(id + "-new-button")) document.getElementById(id + "-new-button").onclick = rulerbutton.fn;
        rulerbutton.buttonisclick = false;
        if (document.getElementById("mm-ruler-del-button") && rulerbutton.hasline) {
            document.getElementById('mm-ruler-del-button').style.display = 'inline';
            if (document.getElementById("mm-ruler-del-button-off")) document.getElementById('mm-ruler-del-button-off').style.display = 'none';
        }
    }
    else {

        if (document.getElementById(id + "-off")) document.getElementById(id + "-off").style.display = 'none';
        if (document.getElementById(id + "-on")) {
            document.getElementById(id + "-on").style.display = 'inline';
        }

        if (document.getElementById(id + "-new-button")) rulerbutton.fn = document.getElementById(id + "-new-button").onclick;
        if (document.getElementById(id + "-new-button")) document.getElementById(id + "-new-button").onclick = rulerbutton.stopLine;
        if (document.getElementById(unclickbutton + "-new-button")) document.getElementById(unclickbutton + "-new-button").onclick = rulerbutton.stopLine;


        rulerbutton.buttonisclick = true;
        if (document.getElementById("mm-ruler-del-button")) document.getElementById('mm-ruler-del-button').style.display = 'none';
        if (document.getElementById("mm-ruler-del-button-off")) document.getElementById('mm-ruler-del-button-off').style.display = 'inline';
        if (id == 'mm-ruler') {
            document.selectedShape = rulerbutton.addShape(1);
        } else if (id == 'mm-poly') {
            document.selectedShape = rulerbutton.addShape(0);
        }
    }
}

MMCanvas.prototype.stopLine = function() {
    this.rulerbutton.shapes[this.rulerbutton.numshapes - 1].setListenToEvents(false);
}

MMCanvas.prototype.displayShape = function(txt) {
    var canvas = document.MMCanvas;
    if (typeof (document.allreadyShape) != 'undefined' && document.allreadyShape.length > 0) {
        for (var i = 0; i < document.allreadyShape.length; i++) {
            document.allreadyShape[i][1].clearLine();
        }
    }

    document.myShape = new Array();
    document.allreadyShape = new Array();
    var pos = canvas.getWhere(canvas.mmmap.getMapDiv());
    var divpanel = document.createElement('div');
    divpanel.style.position = 'absolute';
    divpanel.style.left = pos.left + 5 + 'px';
    divpanel.style.top = pos.top + 40 + 'px';
    divpanel.style.backgroundColor = '#FFFFFF';
    divpanel.style.width = '200px';
    divpanel.style.border = '1px solid black';
    divpanel.style.zIndex = '501';
    divpanel.style.height = (parseInt(document.getElementById("mmmap_div").style.height.replace('px', '')) - 100) + 'px';
    divpanel.style.overflow = 'auto';
    divpanel.innerHTML = '<div align="center" style="width:100%; border-bottom:1px solid black;"><strong>My Shape<strong></div>';
    var divtxt = '';
    var shape = eval('(' + txt + ')');
    for (var i = 0; i < shape.length; i++) {
        document.myShape.push(shape[i]);
        divtxt += '<div id="shape_' + i + '_button"><span style="cursor:pointer;" onclick="document.MMCanvas.display(' + i + ')">' + shape[i].name + '</span> <a onclick="document.MMCanvas.deleteShape(' + i + ')">delete</a></div>';
    }
    if (divtxt == '') {
        divtxt = '<div>No shape found.</div>';
    }
    divpanel.innerHTML += divtxt;
    document.getElementsByTagName("body")[0].appendChild(divpanel);

}

MMCanvas.prototype.display = function(id) {
    var shape = document.myShape[id];
    var canvas = document.MMCanvas;
    //find shapes already draw
    for (var i = 0; i < document.allreadyShape.length; i++) {
        if (document.allreadyShape[i][0] == shape.sid) {
            var lat;
            var lon;
            if (shape.mode == '1') {
                lat = (parseFloat(shape.point[0].lat) + parseFloat(shape.point[1].lat)) / 2;
                lon = (parseFloat(shape.point[0].lon) + parseFloat(shape.point[1].lon)) / 2;
            } else if (shape.mode == '0') {
                lat = (parseFloat(shape.point[0].lat) + parseFloat(shape.point[1].lat) + parseFloat(shape.point[2].lat)) / 3;
                lon = (parseFloat(shape.point[0].lon) + parseFloat(shape.point[1].lon) + parseFloat(shape.point[2].lon)) / 3;
            }
            document.allreadyShape[i][1].editPopup(lat, lon);
            return false;
        }
    }
    var s = canvas.addShape(shape.mode);

    //canvas.rulerbutton.shapes.push(s);
    //canvas.rulerbutton.numshapes++;

    s.setID(shape.sid);
    document.allreadyShape.push([shape.sid, s]);
    var point = new Array();
    for (var j = 0; j < shape.point.length; j++) {
        point.push([shape.point[j].lat, shape.point[j].lon]);
    }
    if (shape.mode == '0') point.pop();
    s.setMode(shape.mode);
    s.setLineColor("#0000FF");
    s.setLineOpacity(1); // 0-1
    if (shape.mode == '0') {
        s.setFillColor("#FF83CD");
        s.setFillOpacity(0.5); // 0-1
    }
    s.setPoints(point);
    s.setListenToEvents(false, true);
    document.selectedShape = s;
}

MMCanvas.prototype.loadShape = function() {

    loadURL = 'shape/load';
    var canvas = (typeof (this.canvas) != 'undefined' && this.canvas.ajax) ? this.canvas : document.MMCanvas;
    new canvas.ajax(loadURL, '', canvas.displayShape, canvas);
}

MMCanvas.prototype.deleteShape = function(id) {
    /*deleteURL = 'shape/del?sid='+id;
    var canvas = document.MMCanvas;
    callBackFn = function() {
    var list = document.getElementById('shape_'+id+'_button');
    list.parentNode.removeChild(list);
    document.selectedShape.clearLine();
    document.selectedShape.deleteShape();
    closeLocationDetailPopup();
    }
    callBackFn();*/
    //new  canvas.ajax(deleteURL, '', callBackFn, canvas);

    var list = document.getElementById('shape_' + id + '_button');
    if (list) list.parentNode.removeChild(list);
    if (this.delshapecallback) this.delshapecallback(id);
    //this.shapes[id].clearLine();
    //this.shapes[id].deleteShape();
    //this.rulerbutton.shapes = '';
    delete this.shapes[id];
    closeLocationDetailPopup();
}

MMCanvas.prototype.newAjaxRequest = function() {
    var xmlreq = false;
    if (window.XMLHttpRequest) {
        xmlreq = new window.XMLHttpRequest();
    }
    else if (window.ActiveXObject) {
        try {
            xmlreq = new ActiveXObject("Msxml2.XMLHTTP");
        } catch (e1) {
            try {
                xmlreq = ActivXObject("Microsoft.XMLHTTP");
            } catch (e2) {
                xmlreq = false;
            }
        }
    }
    return xmlreq;
}

MMCanvas.prototype.getReadyStateHandler = function(req, responseXmlHandler) {
    return function() {
        if (req.readyState == 4) {
            if (req.status == 200) {
                responseXmlHandler(req.responseText);
            }
            else {
                //Error, then refresh the page
                alert('Failed to send data to the server.Now Refreshing this page.')
                //location.reload(true);
            }
        }
    };
}


MMCanvas.prototype.ajax = function(URL, parameters, _callBack, obj) {
    var ajax = new obj.newAjaxRequest();
    if (_callBack) {
        ajax.onreadystatechange = obj.getReadyStateHandler(ajax, _callBack);
    }
    ajax.open("POST", URL, true);
    ajax.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    if (typeof (extendParameters) != 'undefined') {
        ajax.send(parameters + '&' + extendParameters);
    }
    else {
        ajax.send(parameters);
    }
}

MMCanvas.prototype.getAllShapes = function() {
    return this.shapes;
}

MMCanvas.prototype.setAddShapeCallback = function(fn) {
    this.addshapecallback = fn;
}

MMCanvas.prototype.setDeleteShapeCallback = function(fn) {
    this.delshapecallback = fn;
}

MMCanvas.prototype.getLastShape = function() {
    return this.shapes[this.shapes.length - 1];
}
/*
Copyright (c) 2008, Yahoo! Inc. All rights reserved.
Code licensed under the BSD License:
http://developer.yahoo.net/yui/license.txt
version: 2.6.0
*/
if (typeof YAHOO == "undefined" || !YAHOO) { var YAHOO = {}; } YAHOO.namespace = function() { var A = arguments, E = null, C, B, D; for (C = 0; C < A.length; C = C + 1) { D = A[C].split("."); E = YAHOO; for (B = (D[0] == "YAHOO") ? 1 : 0; B < D.length; B = B + 1) { E[D[B]] = E[D[B]] || {}; E = E[D[B]]; } } return E; }; YAHOO.log = function(D, A, C) { var B = YAHOO.widget.Logger; if (B && B.log) { return B.log(D, A, C); } else { return false; } }; YAHOO.register = function(A, E, D) { var I = YAHOO.env.modules; if (!I[A]) { I[A] = { versions: [], builds: [] }; } var B = I[A], H = D.version, G = D.build, F = YAHOO.env.listeners; B.name = A; B.version = H; B.build = G; B.versions.push(H); B.builds.push(G); B.mainClass = E; for (var C = 0; C < F.length; C = C + 1) { F[C](B); } if (E) { E.VERSION = H; E.BUILD = G; } else { YAHOO.log("mainClass is undefined for module " + A, "warn"); } }; YAHOO.env = YAHOO.env || { modules: [], listeners: [] }; YAHOO.env.getVersion = function(A) { return YAHOO.env.modules[A] || null; }; YAHOO.env.ua = function() { var C = { ie: 0, opera: 0, gecko: 0, webkit: 0, mobile: null, air: 0 }; var B = navigator.userAgent, A; if ((/KHTML/).test(B)) { C.webkit = 1; } A = B.match(/AppleWebKit\/([^\s]*)/); if (A && A[1]) { C.webkit = parseFloat(A[1]); if (/ Mobile\//.test(B)) { C.mobile = "Apple"; } else { A = B.match(/NokiaN[^\/]*/); if (A) { C.mobile = A[0]; } } A = B.match(/AdobeAIR\/([^\s]*)/); if (A) { C.air = A[0]; } } if (!C.webkit) { A = B.match(/Opera[\s\/]([^\s]*)/); if (A && A[1]) { C.opera = parseFloat(A[1]); A = B.match(/Opera Mini[^;]*/); if (A) { C.mobile = A[0]; } } else { A = B.match(/MSIE\s([^;]*)/); if (A && A[1]) { C.ie = parseFloat(A[1]); } else { A = B.match(/Gecko\/([^\s]*)/); if (A) { C.gecko = 1; A = B.match(/rv:([^\s\)]*)/); if (A && A[1]) { C.gecko = parseFloat(A[1]); } } } } } return C; } (); (function() { YAHOO.namespace("util", "widget", "example"); if ("undefined" !== typeof YAHOO_config) { var B = YAHOO_config.listener, A = YAHOO.env.listeners, D = true, C; if (B) { for (C = 0; C < A.length; C = C + 1) { if (A[C] == B) { D = false; break; } } if (D) { A.push(B); } } } })(); YAHOO.lang = YAHOO.lang || {}; (function() { var A = YAHOO.lang, C = ["toString", "valueOf"], B = { isArray: function(D) { if (D) { return A.isNumber(D.length) && A.isFunction(D.splice); } return false; }, isBoolean: function(D) { return typeof D === "boolean"; }, isFunction: function(D) { return typeof D === "function"; }, isNull: function(D) { return D === null; }, isNumber: function(D) { return typeof D === "number" && isFinite(D); }, isObject: function(D) { return (D && (typeof D === "object" || A.isFunction(D))) || false; }, isString: function(D) { return typeof D === "string"; }, isUndefined: function(D) { return typeof D === "undefined"; }, _IEEnumFix: (YAHOO.env.ua.ie) ? function(F, E) { for (var D = 0; D < C.length; D = D + 1) { var H = C[D], G = E[H]; if (A.isFunction(G) && G != Object.prototype[H]) { F[H] = G; } } } : function() { }, extend: function(H, I, G) { if (!I || !H) { throw new Error("extend failed, please check that " + "all dependencies are included."); } var E = function() { }; E.prototype = I.prototype; H.prototype = new E(); H.prototype.constructor = H; H.superclass = I.prototype; if (I.prototype.constructor == Object.prototype.constructor) { I.prototype.constructor = I; } if (G) { for (var D in G) { if (A.hasOwnProperty(G, D)) { H.prototype[D] = G[D]; } } A._IEEnumFix(H.prototype, G); } }, augmentObject: function(H, G) { if (!G || !H) { throw new Error("Absorb failed, verify dependencies."); } var D = arguments, F, I, E = D[2]; if (E && E !== true) { for (F = 2; F < D.length; F = F + 1) { H[D[F]] = G[D[F]]; } } else { for (I in G) { if (E || !(I in H)) { H[I] = G[I]; } } A._IEEnumFix(H, G); } }, augmentProto: function(G, F) { if (!F || !G) { throw new Error("Augment failed, verify dependencies."); } var D = [G.prototype, F.prototype]; for (var E = 2; E < arguments.length; E = E + 1) { D.push(arguments[E]); } A.augmentObject.apply(this, D); }, dump: function(D, I) { var F, H, K = [], L = "{...}", E = "f(){...}", J = ", ", G = " => "; if (!A.isObject(D)) { return D + ""; } else { if (D instanceof Date || ("nodeType" in D && "tagName" in D)) { return D; } else { if (A.isFunction(D)) { return E; } } } I = (A.isNumber(I)) ? I : 3; if (A.isArray(D)) { K.push("["); for (F = 0, H = D.length; F < H; F = F + 1) { if (A.isObject(D[F])) { K.push((I > 0) ? A.dump(D[F], I - 1) : L); } else { K.push(D[F]); } K.push(J); } if (K.length > 1) { K.pop(); } K.push("]"); } else { K.push("{"); for (F in D) { if (A.hasOwnProperty(D, F)) { K.push(F + G); if (A.isObject(D[F])) { K.push((I > 0) ? A.dump(D[F], I - 1) : L); } else { K.push(D[F]); } K.push(J); } } if (K.length > 1) { K.pop(); } K.push("}"); } return K.join(""); }, substitute: function(S, E, L) { var I, H, G, O, P, R, N = [], F, J = "dump", M = " ", D = "{", Q = "}"; for (; ; ) { I = S.lastIndexOf(D); if (I < 0) { break; } H = S.indexOf(Q, I); if (I + 1 >= H) { break; } F = S.substring(I + 1, H); O = F; R = null; G = O.indexOf(M); if (G > -1) { R = O.substring(G + 1); O = O.substring(0, G); } P = E[O]; if (L) { P = L(O, P, R); } if (A.isObject(P)) { if (A.isArray(P)) { P = A.dump(P, parseInt(R, 10)); } else { R = R || ""; var K = R.indexOf(J); if (K > -1) { R = R.substring(4); } if (P.toString === Object.prototype.toString || K > -1) { P = A.dump(P, parseInt(R, 10)); } else { P = P.toString(); } } } else { if (!A.isString(P) && !A.isNumber(P)) { P = "~-" + N.length + "-~"; N[N.length] = F; } } S = S.substring(0, I) + P + S.substring(H + 1); } for (I = N.length - 1; I >= 0; I = I - 1) { S = S.replace(new RegExp("~-" + I + "-~"), "{" + N[I] + "}", "g"); } return S; }, trim: function(D) { try { return D.replace(/^\s+|\s+$/g, ""); } catch (E) { return D; } }, merge: function() { var G = {}, E = arguments; for (var F = 0, D = E.length; F < D; F = F + 1) { A.augmentObject(G, E[F], true); } return G; }, later: function(K, E, L, G, H) { K = K || 0; E = E || {}; var F = L, J = G, I, D; if (A.isString(L)) { F = E[L]; } if (!F) { throw new TypeError("method undefined"); } if (!A.isArray(J)) { J = [G]; } I = function() { F.apply(E, J); }; D = (H) ? setInterval(I, K) : setTimeout(I, K); return { interval: H, cancel: function() { if (this.interval) { clearInterval(D); } else { clearTimeout(D); } } }; }, isValue: function(D) { return (A.isObject(D) || A.isString(D) || A.isNumber(D) || A.isBoolean(D)); } }; A.hasOwnProperty = (Object.prototype.hasOwnProperty) ? function(D, E) { return D && D.hasOwnProperty(E); } : function(D, E) { return !A.isUndefined(D[E]) && D.constructor.prototype[E] !== D[E]; }; B.augmentObject(A, B, true); YAHOO.util.Lang = A; A.augment = A.augmentProto; YAHOO.augment = A.augmentProto; YAHOO.extend = A.extend; })(); YAHOO.register("yahoo", YAHOO, { version: "2.6.0", build: "1321" }); (function() {
    var B = YAHOO.util, F = YAHOO.lang, L, J, K = {}, G = {}, N = window.document; YAHOO.env._id_counter = YAHOO.env._id_counter || 0; var C = YAHOO.env.ua.opera, M = YAHOO.env.ua.webkit, A = YAHOO.env.ua.gecko, H = YAHOO.env.ua.ie; var E = { HYPHEN: /(-[a-z])/i, ROOT_TAG: /^body|html$/i, OP_SCROLL: /^(?:inline|table-row)$/i }; var O = function(Q) { if (!E.HYPHEN.test(Q)) { return Q; } if (K[Q]) { return K[Q]; } var R = Q; while (E.HYPHEN.exec(R)) { R = R.replace(RegExp.$1, RegExp.$1.substr(1).toUpperCase()); } K[Q] = R; return R; }; var P = function(R) { var Q = G[R]; if (!Q) { Q = new RegExp("(?:^|\\s+)" + R + "(?:\\s+|$)"); G[R] = Q; } return Q; }; if (N.defaultView && N.defaultView.getComputedStyle) { L = function(Q, T) { var S = null; if (T == "float") { T = "cssFloat"; } var R = Q.ownerDocument.defaultView.getComputedStyle(Q, ""); if (R) { S = R[O(T)]; } return Q.style[T] || S; }; } else { if (N.documentElement.currentStyle && H) { L = function(Q, S) { switch (O(S)) { case "opacity": var U = 100; try { U = Q.filters["DXImageTransform.Microsoft.Alpha"].opacity; } catch (T) { try { U = Q.filters("alpha").opacity; } catch (T) { } } return U / 100; case "float": S = "styleFloat"; default: var R = Q.currentStyle ? Q.currentStyle[S] : null; return (Q.style[S] || R); } }; } else { L = function(Q, R) { return Q.style[R]; }; } } if (H) { J = function(Q, R, S) { switch (R) { case "opacity": if (F.isString(Q.style.filter)) { Q.style.filter = "alpha(opacity=" + S * 100 + ")"; if (!Q.currentStyle || !Q.currentStyle.hasLayout) { Q.style.zoom = 1; } } break; case "float": R = "styleFloat"; default: Q.style[R] = S; } }; } else { J = function(Q, R, S) { if (R == "float") { R = "cssFloat"; } Q.style[R] = S; }; } var D = function(Q, R) { return Q && Q.nodeType == 1 && (!R || R(Q)); }; YAHOO.util.Dom = { get: function(S) { if (S) { if (S.nodeType || S.item) { return S; } if (typeof S === "string") { return N.getElementById(S); } if ("length" in S) { var T = []; for (var R = 0, Q = S.length; R < Q; ++R) { T[T.length] = B.Dom.get(S[R]); } return T; } return S; } return null; }, getStyle: function(Q, S) { S = O(S); var R = function(T) { return L(T, S); }; return B.Dom.batch(Q, R, B.Dom, true); }, setStyle: function(Q, S, T) { S = O(S); var R = function(U) { J(U, S, T); }; B.Dom.batch(Q, R, B.Dom, true); }, getXY: function(Q) { var R = function(S) { if ((S.parentNode === null || S.offsetParent === null || this.getStyle(S, "display") == "none") && S != S.ownerDocument.body) { return false; } return I(S); }; return B.Dom.batch(Q, R, B.Dom, true); }, getX: function(Q) { var R = function(S) { return B.Dom.getXY(S)[0]; }; return B.Dom.batch(Q, R, B.Dom, true); }, getY: function(Q) { var R = function(S) { return B.Dom.getXY(S)[1]; }; return B.Dom.batch(Q, R, B.Dom, true); }, setXY: function(Q, T, S) { var R = function(W) { var V = this.getStyle(W, "position"); if (V == "static") { this.setStyle(W, "position", "relative"); V = "relative"; } var Y = this.getXY(W); if (Y === false) { return false; } var X = [parseInt(this.getStyle(W, "left"), 10), parseInt(this.getStyle(W, "top"), 10)]; if (isNaN(X[0])) { X[0] = (V == "relative") ? 0 : W.offsetLeft; } if (isNaN(X[1])) { X[1] = (V == "relative") ? 0 : W.offsetTop; } if (T[0] !== null) { W.style.left = T[0] - Y[0] + X[0] + "px"; } if (T[1] !== null) { W.style.top = T[1] - Y[1] + X[1] + "px"; } if (!S) { var U = this.getXY(W); if ((T[0] !== null && U[0] != T[0]) || (T[1] !== null && U[1] != T[1])) { this.setXY(W, T, true); } } }; B.Dom.batch(Q, R, B.Dom, true); }, setX: function(R, Q) { B.Dom.setXY(R, [Q, null]); }, setY: function(Q, R) { B.Dom.setXY(Q, [null, R]); }, getRegion: function(Q) { var R = function(S) { if ((S.parentNode === null || S.offsetParent === null || this.getStyle(S, "display") == "none") && S != S.ownerDocument.body) { return false; } var T = B.Region.getRegion(S); return T; }; return B.Dom.batch(Q, R, B.Dom, true); }, getClientWidth: function() { return B.Dom.getViewportWidth(); }, getClientHeight: function() { return B.Dom.getViewportHeight(); }, getElementsByClassName: function(U, Y, V, W) { U = F.trim(U); Y = Y || "*"; V = (V) ? B.Dom.get(V) : null || N; if (!V) { return []; } var R = [], Q = V.getElementsByTagName(Y), X = P(U); for (var S = 0, T = Q.length; S < T; ++S) { if (X.test(Q[S].className)) { R[R.length] = Q[S]; if (W) { W.call(Q[S], Q[S]); } } } return R; }, hasClass: function(S, R) { var Q = P(R); var T = function(U) { return Q.test(U.className); }; return B.Dom.batch(S, T, B.Dom, true); }, addClass: function(R, Q) { var S = function(T) { if (this.hasClass(T, Q)) { return false; } T.className = F.trim([T.className, Q].join(" ")); return true; }; return B.Dom.batch(R, S, B.Dom, true); }, removeClass: function(S, R) { var Q = P(R); var T = function(W) { var V = false, X = W.className; if (R && X && this.hasClass(W, R)) { W.className = X.replace(Q, " "); if (this.hasClass(W, R)) { this.removeClass(W, R); } W.className = F.trim(W.className); if (W.className === "") { var U = (W.hasAttribute) ? "class" : "className"; W.removeAttribute(U); } V = true; } return V; }; return B.Dom.batch(S, T, B.Dom, true); }, replaceClass: function(T, R, Q) { if (!Q || R === Q) { return false; } var S = P(R); var U = function(V) { if (!this.hasClass(V, R)) { this.addClass(V, Q); return true; } V.className = V.className.replace(S, " " + Q + " "); if (this.hasClass(V, R)) { this.removeClass(V, R); } V.className = F.trim(V.className); return true; }; return B.Dom.batch(T, U, B.Dom, true); }, generateId: function(Q, S) { S = S || "yui-gen"; var R = function(T) { if (T && T.id) { return T.id; } var U = S + YAHOO.env._id_counter++; if (T) { T.id = U; } return U; }; return B.Dom.batch(Q, R, B.Dom, true) || R.apply(B.Dom, arguments); }, isAncestor: function(R, S) { R = B.Dom.get(R); S = B.Dom.get(S); var Q = false; if ((R && S) && (R.nodeType && S.nodeType)) { if (R.contains && R !== S) { Q = R.contains(S); } else { if (R.compareDocumentPosition) { Q = !!(R.compareDocumentPosition(S) & 16); } } } else { } return Q; }, inDocument: function(Q) { return this.isAncestor(N.documentElement, Q); }, getElementsBy: function(X, R, S, U) { R = R || "*"; S = (S) ? B.Dom.get(S) : null || N; if (!S) { return []; } var T = [], W = S.getElementsByTagName(R); for (var V = 0, Q = W.length; V < Q; ++V) { if (X(W[V])) { T[T.length] = W[V]; if (U) { U(W[V]); } } } return T; }, batch: function(U, X, W, S) { U = (U && (U.tagName || U.item)) ? U : B.Dom.get(U); if (!U || !X) { return false; } var T = (S) ? W : window; if (U.tagName || U.length === undefined) { return X.call(T, U, W); } var V = []; for (var R = 0, Q = U.length; R < Q; ++R) { V[V.length] = X.call(T, U[R], W); } return V; }, getDocumentHeight: function() { var R = (N.compatMode != "CSS1Compat") ? N.body.scrollHeight : N.documentElement.scrollHeight; var Q = Math.max(R, B.Dom.getViewportHeight()); return Q; }, getDocumentWidth: function() { var R = (N.compatMode != "CSS1Compat") ? N.body.scrollWidth : N.documentElement.scrollWidth; var Q = Math.max(R, B.Dom.getViewportWidth()); return Q; }, getViewportHeight: function() {
        var Q = self.innerHeight;
        var R = N.compatMode; if ((R || H) && !C) { Q = (R == "CSS1Compat") ? N.documentElement.clientHeight : N.body.clientHeight; } return Q;
    }, getViewportWidth: function() { var Q = self.innerWidth; var R = N.compatMode; if (R || H) { Q = (R == "CSS1Compat") ? N.documentElement.clientWidth : N.body.clientWidth; } return Q; }, getAncestorBy: function(Q, R) { while ((Q = Q.parentNode)) { if (D(Q, R)) { return Q; } } return null; }, getAncestorByClassName: function(R, Q) { R = B.Dom.get(R); if (!R) { return null; } var S = function(T) { return B.Dom.hasClass(T, Q); }; return B.Dom.getAncestorBy(R, S); }, getAncestorByTagName: function(R, Q) { R = B.Dom.get(R); if (!R) { return null; } var S = function(T) { return T.tagName && T.tagName.toUpperCase() == Q.toUpperCase(); }; return B.Dom.getAncestorBy(R, S); }, getPreviousSiblingBy: function(Q, R) { while (Q) { Q = Q.previousSibling; if (D(Q, R)) { return Q; } } return null; }, getPreviousSibling: function(Q) { Q = B.Dom.get(Q); if (!Q) { return null; } return B.Dom.getPreviousSiblingBy(Q); }, getNextSiblingBy: function(Q, R) { while (Q) { Q = Q.nextSibling; if (D(Q, R)) { return Q; } } return null; }, getNextSibling: function(Q) { Q = B.Dom.get(Q); if (!Q) { return null; } return B.Dom.getNextSiblingBy(Q); }, getFirstChildBy: function(Q, S) { var R = (D(Q.firstChild, S)) ? Q.firstChild : null; return R || B.Dom.getNextSiblingBy(Q.firstChild, S); }, getFirstChild: function(Q, R) { Q = B.Dom.get(Q); if (!Q) { return null; } return B.Dom.getFirstChildBy(Q); }, getLastChildBy: function(Q, S) { if (!Q) { return null; } var R = (D(Q.lastChild, S)) ? Q.lastChild : null; return R || B.Dom.getPreviousSiblingBy(Q.lastChild, S); }, getLastChild: function(Q) { Q = B.Dom.get(Q); return B.Dom.getLastChildBy(Q); }, getChildrenBy: function(R, T) { var S = B.Dom.getFirstChildBy(R, T); var Q = S ? [S] : []; B.Dom.getNextSiblingBy(S, function(U) { if (!T || T(U)) { Q[Q.length] = U; } return false; }); return Q; }, getChildren: function(Q) { Q = B.Dom.get(Q); if (!Q) { } return B.Dom.getChildrenBy(Q); }, getDocumentScrollLeft: function(Q) { Q = Q || N; return Math.max(Q.documentElement.scrollLeft, Q.body.scrollLeft); }, getDocumentScrollTop: function(Q) { Q = Q || N; return Math.max(Q.documentElement.scrollTop, Q.body.scrollTop); }, insertBefore: function(R, Q) { R = B.Dom.get(R); Q = B.Dom.get(Q); if (!R || !Q || !Q.parentNode) { return null; } return Q.parentNode.insertBefore(R, Q); }, insertAfter: function(R, Q) { R = B.Dom.get(R); Q = B.Dom.get(Q); if (!R || !Q || !Q.parentNode) { return null; } if (Q.nextSibling) { return Q.parentNode.insertBefore(R, Q.nextSibling); } else { return Q.parentNode.appendChild(R); } }, getClientRegion: function() { var S = B.Dom.getDocumentScrollTop(), R = B.Dom.getDocumentScrollLeft(), T = B.Dom.getViewportWidth() + R, Q = B.Dom.getViewportHeight() + S; return new B.Region(S, T, Q, R); } 
    }; var I = function() { if (N.documentElement.getBoundingClientRect) { return function(S) { var T = S.getBoundingClientRect(), R = Math.round; var Q = S.ownerDocument; return [R(T.left + B.Dom.getDocumentScrollLeft(Q)), R(T.top + B.Dom.getDocumentScrollTop(Q))]; }; } else { return function(S) { var T = [S.offsetLeft, S.offsetTop]; var R = S.offsetParent; var Q = (M && B.Dom.getStyle(S, "position") == "absolute" && S.offsetParent == S.ownerDocument.body); if (R != S) { while (R) { T[0] += R.offsetLeft; T[1] += R.offsetTop; if (!Q && M && B.Dom.getStyle(R, "position") == "absolute") { Q = true; } R = R.offsetParent; } } if (Q) { T[0] -= S.ownerDocument.body.offsetLeft; T[1] -= S.ownerDocument.body.offsetTop; } R = S.parentNode; while (R.tagName && !E.ROOT_TAG.test(R.tagName)) { if (R.scrollTop || R.scrollLeft) { T[0] -= R.scrollLeft; T[1] -= R.scrollTop; } R = R.parentNode; } return T; }; } } ();
})(); YAHOO.util.Region = function(C, D, A, B) { this.top = C; this[1] = C; this.right = D; this.bottom = A; this.left = B; this[0] = B; }; YAHOO.util.Region.prototype.contains = function(A) { return (A.left >= this.left && A.right <= this.right && A.top >= this.top && A.bottom <= this.bottom); }; YAHOO.util.Region.prototype.getArea = function() { return ((this.bottom - this.top) * (this.right - this.left)); }; YAHOO.util.Region.prototype.intersect = function(E) { var C = Math.max(this.top, E.top); var D = Math.min(this.right, E.right); var A = Math.min(this.bottom, E.bottom); var B = Math.max(this.left, E.left); if (A >= C && D >= B) { return new YAHOO.util.Region(C, D, A, B); } else { return null; } }; YAHOO.util.Region.prototype.union = function(E) { var C = Math.min(this.top, E.top); var D = Math.max(this.right, E.right); var A = Math.max(this.bottom, E.bottom); var B = Math.min(this.left, E.left); return new YAHOO.util.Region(C, D, A, B); }; YAHOO.util.Region.prototype.toString = function() { return ("Region {" + "top: " + this.top + ", right: " + this.right + ", bottom: " + this.bottom + ", left: " + this.left + "}"); }; YAHOO.util.Region.getRegion = function(D) { var F = YAHOO.util.Dom.getXY(D); var C = F[1]; var E = F[0] + D.offsetWidth; var A = F[1] + D.offsetHeight; var B = F[0]; return new YAHOO.util.Region(C, E, A, B); }; YAHOO.util.Point = function(A, B) { if (YAHOO.lang.isArray(A)) { B = A[1]; A = A[0]; } this.x = this.right = this.left = this[0] = A; this.y = this.top = this.bottom = this[1] = B; }; YAHOO.util.Point.prototype = new YAHOO.util.Region(); YAHOO.register("dom", YAHOO.util.Dom, { version: "2.6.0", build: "1321" }); YAHOO.util.CustomEvent = function(D, B, C, A) { this.type = D; this.scope = B || window; this.silent = C; this.signature = A || YAHOO.util.CustomEvent.LIST; this.subscribers = []; if (!this.silent) { } var E = "_YUICEOnSubscribe"; if (D !== E) { this.subscribeEvent = new YAHOO.util.CustomEvent(E, this, true); } this.lastError = null; }; YAHOO.util.CustomEvent.LIST = 0; YAHOO.util.CustomEvent.FLAT = 1; YAHOO.util.CustomEvent.prototype = { subscribe: function(B, C, A) { if (!B) { throw new Error("Invalid callback for subscriber to '" + this.type + "'"); } if (this.subscribeEvent) { this.subscribeEvent.fire(B, C, A); } this.subscribers.push(new YAHOO.util.Subscriber(B, C, A)); }, unsubscribe: function(D, F) { if (!D) { return this.unsubscribeAll(); } var E = false; for (var B = 0, A = this.subscribers.length; B < A; ++B) { var C = this.subscribers[B]; if (C && C.contains(D, F)) { this._delete(B); E = true; } } return E; }, fire: function() { this.lastError = null; var K = [], E = this.subscribers.length; if (!E && this.silent) { return true; } var I = [].slice.call(arguments, 0), G = true, D, J = false; if (!this.silent) { } var C = this.subscribers.slice(), A = YAHOO.util.Event.throwErrors; for (D = 0; D < E; ++D) { var M = C[D]; if (!M) { J = true; } else { if (!this.silent) { } var L = M.getScope(this.scope); if (this.signature == YAHOO.util.CustomEvent.FLAT) { var B = null; if (I.length > 0) { B = I[0]; } try { G = M.fn.call(L, B, M.obj); } catch (F) { this.lastError = F; if (A) { throw F; } } } else { try { G = M.fn.call(L, this.type, I, M.obj); } catch (H) { this.lastError = H; if (A) { throw H; } } } if (false === G) { if (!this.silent) { } break; } } } return (G !== false); }, unsubscribeAll: function() { for (var A = this.subscribers.length - 1; A > -1; A--) { this._delete(A); } this.subscribers = []; return A; }, _delete: function(A) { var B = this.subscribers[A]; if (B) { delete B.fn; delete B.obj; } this.subscribers.splice(A, 1); }, toString: function() { return "CustomEvent: " + "'" + this.type + "', " + "scope: " + this.scope; } }; YAHOO.util.Subscriber = function(B, C, A) { this.fn = B; this.obj = YAHOO.lang.isUndefined(C) ? null : C; this.override = A; }; YAHOO.util.Subscriber.prototype.getScope = function(A) { if (this.override) { if (this.override === true) { return this.obj; } else { return this.override; } } return A; }; YAHOO.util.Subscriber.prototype.contains = function(A, B) { if (B) { return (this.fn == A && this.obj == B); } else { return (this.fn == A); } }; YAHOO.util.Subscriber.prototype.toString = function() { return "Subscriber { obj: " + this.obj + ", override: " + (this.override || "no") + " }"; }; if (!YAHOO.util.Event) {
    YAHOO.util.Event = function() {
        var H = false; var I = []; var J = []; var G = []; var E = []; var C = 0; var F = []; var B = []; var A = 0; var D = { 63232: 38, 63233: 40, 63234: 37, 63235: 39, 63276: 33, 63277: 34, 25: 9 }; var K = YAHOO.env.ua.ie ? "focusin" : "focus"; var L = YAHOO.env.ua.ie ? "focusout" : "blur"; return { POLL_RETRYS: 2000, POLL_INTERVAL: 20, EL: 0, TYPE: 1, FN: 2, WFN: 3, UNLOAD_OBJ: 3, ADJ_SCOPE: 4, OBJ: 5, OVERRIDE: 6, CAPTURE: 7, lastError: null, isSafari: YAHOO.env.ua.webkit, webkit: YAHOO.env.ua.webkit, isIE: YAHOO.env.ua.ie, _interval: null, _dri: null, DOMReady: false, throwErrors: false, startInterval: function() { if (!this._interval) { var M = this; var N = function() { M._tryPreloadAttach(); }; this._interval = setInterval(N, this.POLL_INTERVAL); } }, onAvailable: function(R, O, S, Q, P) { var M = (YAHOO.lang.isString(R)) ? [R] : R; for (var N = 0; N < M.length; N = N + 1) { F.push({ id: M[N], fn: O, obj: S, override: Q, checkReady: P }); } C = this.POLL_RETRYS; this.startInterval(); }, onContentReady: function(O, M, P, N) { this.onAvailable(O, M, P, N, true); }, onDOMReady: function(M, O, N) { if (this.DOMReady) { setTimeout(function() { var P = window; if (N) { if (N === true) { P = O; } else { P = N; } } M.call(P, "DOMReady", [], O); }, 0); } else { this.DOMReadyEvent.subscribe(M, O, N); } }, _addListener: function(O, M, X, S, N, a) { if (!X || !X.call) { return false; } if (this._isValidCollection(O)) { var Y = true; for (var T = 0, V = O.length; T < V; ++T) { Y = this._addListener(O[T], M, X, S, N, a) && Y; } return Y; } else { if (YAHOO.lang.isString(O)) { var R = this.getEl(O); if (R) { O = R; } else { this.onAvailable(O, function() { YAHOO.util.Event._addListener(O, M, X, S, N, a); }); return true; } } } if (!O) { return false; } if ("unload" == M && S !== this) { J[J.length] = [O, M, X, S, N, a]; return true; } var b = O; if (N) { if (N === true) { b = S; } else { b = N; } } var P = function(c) { return X.call(b, YAHOO.util.Event.getEvent(c, O), S); }; var Z = [O, M, X, P, b, S, N, a]; var U = I.length; I[U] = Z; if (this.useLegacyEvent(O, M)) { var Q = this.getLegacyIndex(O, M); if (Q == -1 || O != G[Q][0]) { Q = G.length; B[O.id + M] = Q; G[Q] = [O, M, O["on" + M]]; E[Q] = []; O["on" + M] = function(c) { YAHOO.util.Event.fireLegacyEvent(YAHOO.util.Event.getEvent(c), Q); }; } E[Q].push(Z); } else { try { this._simpleAdd(O, M, P, a); } catch (W) { this.lastError = W; this._removeListener(O, M, X, a); return false; } } return true; }, addListener: function(O, Q, N, P, M) { return this._addListener(O, Q, N, P, M, false); }, addFocusListener: function(O, N, P, M) { return this._addListener(O, K, N, P, M, true); }, removeFocusListener: function(N, M) { return this._removeListener(N, K, M, true); }, addBlurListener: function(O, N, P, M) { return this._addListener(O, L, N, P, M, true); }, removeBlurListener: function(N, M) { return this._removeListener(N, L, M, true); }, fireLegacyEvent: function(Q, O) { var S = true, M, U, T, V, R; U = E[O].slice(); for (var N = 0, P = U.length; N < P; ++N) { T = U[N]; if (T && T[this.WFN]) { V = T[this.ADJ_SCOPE]; R = T[this.WFN].call(V, Q); S = (S && R); } } M = G[O]; if (M && M[2]) { M[2](Q); } return S; }, getLegacyIndex: function(N, O) { var M = this.generateId(N) + O; if (typeof B[M] == "undefined") { return -1; } else { return B[M]; } }, useLegacyEvent: function(M, N) { return (this.webkit && this.webkit < 419 && ("click" == N || "dblclick" == N)); }, _removeListener: function(N, M, V, Y) {
            var Q, T, X; if (typeof N == "string") { N = this.getEl(N); } else { if (this._isValidCollection(N)) { var W = true; for (Q = N.length - 1; Q > -1; Q--) { W = (this._removeListener(N[Q], M, V, Y) && W); } return W; } } if (!V || !V.call) { return this.purgeElement(N, false, M); } if ("unload" == M) { for (Q = J.length - 1; Q > -1; Q--) { X = J[Q]; if (X && X[0] == N && X[1] == M && X[2] == V) { J.splice(Q, 1); return true; } } return false; } var R = null; var S = arguments[4]; if ("undefined" === typeof S) { S = this._getCacheIndex(N, M, V); } if (S >= 0) { R = I[S]; } if (!N || !R) { return false; } if (this.useLegacyEvent(N, M)) { var P = this.getLegacyIndex(N, M); var O = E[P]; if (O) { for (Q = 0, T = O.length; Q < T; ++Q) { X = O[Q]; if (X && X[this.EL] == N && X[this.TYPE] == M && X[this.FN] == V) { O.splice(Q, 1); break; } } } } else { try { this._simpleRemove(N, M, R[this.WFN], Y); } catch (U) { this.lastError = U; return false; } } delete I[S][this.WFN]; delete I[S][this.FN];
            I.splice(S, 1); return true;
        }, removeListener: function(N, O, M) { return this._removeListener(N, O, M, false); }, getTarget: function(O, N) { var M = O.target || O.srcElement; return this.resolveTextNode(M); }, resolveTextNode: function(N) { try { if (N && 3 == N.nodeType) { return N.parentNode; } } catch (M) { } return N; }, getPageX: function(N) { var M = N.pageX; if (!M && 0 !== M) { M = N.clientX || 0; if (this.isIE) { M += this._getScrollLeft(); } } return M; }, getPageY: function(M) { var N = M.pageY; if (!N && 0 !== N) { N = M.clientY || 0; if (this.isIE) { N += this._getScrollTop(); } } return N; }, getXY: function(M) { return [this.getPageX(M), this.getPageY(M)]; }, getRelatedTarget: function(N) { var M = N.relatedTarget; if (!M) { if (N.type == "mouseout") { M = N.toElement; } else { if (N.type == "mouseover") { M = N.fromElement; } } } return this.resolveTextNode(M); }, getTime: function(O) { if (!O.time) { var N = new Date().getTime(); try { O.time = N; } catch (M) { this.lastError = M; return N; } } return O.time; }, stopEvent: function(M) { this.stopPropagation(M); this.preventDefault(M); }, stopPropagation: function(M) { if (M.stopPropagation) { M.stopPropagation(); } else { M.cancelBubble = true; } }, preventDefault: function(M) { if (M.preventDefault) { M.preventDefault(); } else { M.returnValue = false; } }, getEvent: function(O, M) { var N = O || window.event; if (!N) { var P = this.getEvent.caller; while (P) { N = P.arguments[0]; if (N && Event == N.constructor) { break; } P = P.caller; } } return N; }, getCharCode: function(N) { var M = N.keyCode || N.charCode || 0; if (YAHOO.env.ua.webkit && (M in D)) { M = D[M]; } return M; }, _getCacheIndex: function(Q, R, P) { for (var O = 0, N = I.length; O < N; O = O + 1) { var M = I[O]; if (M && M[this.FN] == P && M[this.EL] == Q && M[this.TYPE] == R) { return O; } } return -1; }, generateId: function(M) { var N = M.id; if (!N) { N = "yuievtautoid-" + A; ++A; M.id = N; } return N; }, _isValidCollection: function(N) { try { return (N && typeof N !== "string" && N.length && !N.tagName && !N.alert && typeof N[0] !== "undefined"); } catch (M) { return false; } }, elCache: {}, getEl: function(M) { return (typeof M === "string") ? document.getElementById(M) : M; }, clearCache: function() { }, DOMReadyEvent: new YAHOO.util.CustomEvent("DOMReady", this), _load: function(N) { if (!H) { H = true; var M = YAHOO.util.Event; M._ready(); M._tryPreloadAttach(); } }, _ready: function(N) { var M = YAHOO.util.Event; if (!M.DOMReady) { M.DOMReady = true; M.DOMReadyEvent.fire(); M._simpleRemove(document, "DOMContentLoaded", M._ready); } }, _tryPreloadAttach: function() { if (F.length === 0) { C = 0; clearInterval(this._interval); this._interval = null; return; } if (this.locked) { return; } if (this.isIE) { if (!this.DOMReady) { this.startInterval(); return; } } this.locked = true; var S = !H; if (!S) { S = (C > 0 && F.length > 0); } var R = []; var T = function(V, W) { var U = V; if (W.override) { if (W.override === true) { U = W.obj; } else { U = W.override; } } W.fn.call(U, W.obj); }; var N, M, Q, P, O = []; for (N = 0, M = F.length; N < M; N = N + 1) { Q = F[N]; if (Q) { P = this.getEl(Q.id); if (P) { if (Q.checkReady) { if (H || P.nextSibling || !S) { O.push(Q); F[N] = null; } } else { T(P, Q); F[N] = null; } } else { R.push(Q); } } } for (N = 0, M = O.length; N < M; N = N + 1) { Q = O[N]; T(this.getEl(Q.id), Q); } C--; if (S) { for (N = F.length - 1; N > -1; N--) { Q = F[N]; if (!Q || !Q.id) { F.splice(N, 1); } } this.startInterval(); } else { clearInterval(this._interval); this._interval = null; } this.locked = false; }, purgeElement: function(Q, R, T) { var O = (YAHOO.lang.isString(Q)) ? this.getEl(Q) : Q; var S = this.getListeners(O, T), P, M; if (S) { for (P = S.length - 1; P > -1; P--) { var N = S[P]; this._removeListener(O, N.type, N.fn, N.capture); } } if (R && O && O.childNodes) { for (P = 0, M = O.childNodes.length; P < M; ++P) { this.purgeElement(O.childNodes[P], R, T); } } }, getListeners: function(O, M) { var R = [], N; if (!M) { N = [I, J]; } else { if (M === "unload") { N = [J]; } else { N = [I]; } } var T = (YAHOO.lang.isString(O)) ? this.getEl(O) : O; for (var Q = 0; Q < N.length; Q = Q + 1) { var V = N[Q]; if (V) { for (var S = 0, U = V.length; S < U; ++S) { var P = V[S]; if (P && P[this.EL] === T && (!M || M === P[this.TYPE])) { R.push({ type: P[this.TYPE], fn: P[this.FN], obj: P[this.OBJ], adjust: P[this.OVERRIDE], scope: P[this.ADJ_SCOPE], capture: P[this.CAPTURE], index: S }); } } } } return (R.length) ? R : null; }, _unload: function(S) { var M = YAHOO.util.Event, P, O, N, R, Q, T = J.slice(); for (P = 0, R = J.length; P < R; ++P) { N = T[P]; if (N) { var U = window; if (N[M.ADJ_SCOPE]) { if (N[M.ADJ_SCOPE] === true) { U = N[M.UNLOAD_OBJ]; } else { U = N[M.ADJ_SCOPE]; } } N[M.FN].call(U, M.getEvent(S, N[M.EL]), N[M.UNLOAD_OBJ]); T[P] = null; N = null; U = null; } } J = null; if (I) { for (O = I.length - 1; O > -1; O--) { N = I[O]; if (N) { M._removeListener(N[M.EL], N[M.TYPE], N[M.FN], N[M.CAPTURE], O); } } N = null; } G = null; M._simpleRemove(window, "unload", M._unload); }, _getScrollLeft: function() { return this._getScroll()[1]; }, _getScrollTop: function() { return this._getScroll()[0]; }, _getScroll: function() { var M = document.documentElement, N = document.body; if (M && (M.scrollTop || M.scrollLeft)) { return [M.scrollTop, M.scrollLeft]; } else { if (N) { return [N.scrollTop, N.scrollLeft]; } else { return [0, 0]; } } }, regCE: function() { }, _simpleAdd: function() { if (window.addEventListener) { return function(O, P, N, M) { O.addEventListener(P, N, (M)); }; } else { if (window.attachEvent) { return function(O, P, N, M) { O.attachEvent("on" + P, N); }; } else { return function() { }; } } } (), _simpleRemove: function() { if (window.removeEventListener) { return function(O, P, N, M) { O.removeEventListener(P, N, (M)); }; } else { if (window.detachEvent) { return function(N, O, M) { N.detachEvent("on" + O, M); }; } else { return function() { }; } } } ()
        };
    } (); (function() {
        var EU = YAHOO.util.Event; EU.on = EU.addListener; EU.onFocus = EU.addFocusListener; EU.onBlur = EU.addBlurListener;
        /* DOMReady: based on work by: Dean Edwards/John Resig/Matthias Miller */
        if (EU.isIE) { YAHOO.util.Event.onDOMReady(YAHOO.util.Event._tryPreloadAttach, YAHOO.util.Event, true); var n = document.createElement("p"); EU._dri = setInterval(function() { try { n.doScroll("left"); clearInterval(EU._dri); EU._dri = null; EU._ready(); n = null; } catch (ex) { } }, EU.POLL_INTERVAL); } else { if (EU.webkit && EU.webkit < 525) { EU._dri = setInterval(function() { var rs = document.readyState; if ("loaded" == rs || "complete" == rs) { clearInterval(EU._dri); EU._dri = null; EU._ready(); } }, EU.POLL_INTERVAL); } else { EU._simpleAdd(document, "DOMContentLoaded", EU._ready); } } EU._simpleAdd(window, "load", EU._load); EU._simpleAdd(window, "unload", EU._unload); EU._tryPreloadAttach();
    })();
} YAHOO.util.EventProvider = function() { }; YAHOO.util.EventProvider.prototype = { __yui_events: null, __yui_subscribers: null, subscribe: function(A, C, F, E) {
    this.__yui_events = this.__yui_events || {};
    var D = this.__yui_events[A]; if (D) { D.subscribe(C, F, E); } else { this.__yui_subscribers = this.__yui_subscribers || {}; var B = this.__yui_subscribers; if (!B[A]) { B[A] = []; } B[A].push({ fn: C, obj: F, override: E }); } 
}, unsubscribe: function(C, E, G) { this.__yui_events = this.__yui_events || {}; var A = this.__yui_events; if (C) { var F = A[C]; if (F) { return F.unsubscribe(E, G); } } else { var B = true; for (var D in A) { if (YAHOO.lang.hasOwnProperty(A, D)) { B = B && A[D].unsubscribe(E, G); } } return B; } return false; }, unsubscribeAll: function(A) { return this.unsubscribe(A); }, createEvent: function(G, D) { this.__yui_events = this.__yui_events || {}; var A = D || {}; var I = this.__yui_events; if (I[G]) { } else { var H = A.scope || this; var E = (A.silent); var B = new YAHOO.util.CustomEvent(G, H, E, YAHOO.util.CustomEvent.FLAT); I[G] = B; if (A.onSubscribeCallback) { B.subscribeEvent.subscribe(A.onSubscribeCallback); } this.__yui_subscribers = this.__yui_subscribers || {}; var F = this.__yui_subscribers[G]; if (F) { for (var C = 0; C < F.length; ++C) { B.subscribe(F[C].fn, F[C].obj, F[C].override); } } } return I[G]; }, fireEvent: function(E, D, A, C) { this.__yui_events = this.__yui_events || {}; var G = this.__yui_events[E]; if (!G) { return null; } var B = []; for (var F = 1; F < arguments.length; ++F) { B.push(arguments[F]); } return G.fire.apply(G, B); }, hasEvent: function(A) { if (this.__yui_events) { if (this.__yui_events[A]) { return true; } } return false; } 
}; YAHOO.util.KeyListener = function(A, F, B, C) { if (!A) { } else { if (!F) { } else { if (!B) { } } } if (!C) { C = YAHOO.util.KeyListener.KEYDOWN; } var D = new YAHOO.util.CustomEvent("keyPressed"); this.enabledEvent = new YAHOO.util.CustomEvent("enabled"); this.disabledEvent = new YAHOO.util.CustomEvent("disabled"); if (typeof A == "string") { A = document.getElementById(A); } if (typeof B == "function") { D.subscribe(B); } else { D.subscribe(B.fn, B.scope, B.correctScope); } function E(J, I) { if (!F.shift) { F.shift = false; } if (!F.alt) { F.alt = false; } if (!F.ctrl) { F.ctrl = false; } if (J.shiftKey == F.shift && J.altKey == F.alt && J.ctrlKey == F.ctrl) { var G; if (F.keys instanceof Array) { for (var H = 0; H < F.keys.length; H++) { G = F.keys[H]; if (G == J.charCode) { D.fire(J.charCode, J); break; } else { if (G == J.keyCode) { D.fire(J.keyCode, J); break; } } } } else { G = F.keys; if (G == J.charCode) { D.fire(J.charCode, J); } else { if (G == J.keyCode) { D.fire(J.keyCode, J); } } } } } this.enable = function() { if (!this.enabled) { YAHOO.util.Event.addListener(A, C, E); this.enabledEvent.fire(F); } this.enabled = true; }; this.disable = function() { if (this.enabled) { YAHOO.util.Event.removeListener(A, C, E); this.disabledEvent.fire(F); } this.enabled = false; }; this.toString = function() { return "KeyListener [" + F.keys + "] " + A.tagName + (A.id ? "[" + A.id + "]" : ""); }; }; YAHOO.util.KeyListener.KEYDOWN = "keydown"; YAHOO.util.KeyListener.KEYUP = "keyup"; YAHOO.util.KeyListener.KEY = { ALT: 18, BACK_SPACE: 8, CAPS_LOCK: 20, CONTROL: 17, DELETE: 46, DOWN: 40, END: 35, ENTER: 13, ESCAPE: 27, HOME: 36, LEFT: 37, META: 224, NUM_LOCK: 144, PAGE_DOWN: 34, PAGE_UP: 33, PAUSE: 19, PRINTSCREEN: 44, RIGHT: 39, SCROLL_LOCK: 145, SHIFT: 16, SPACE: 32, TAB: 9, UP: 38 }; YAHOO.register("event", YAHOO.util.Event, { version: "2.6.0", build: "1321" }); YAHOO.register("yahoo-dom-event", YAHOO, { version: "2.6.0", build: "1321" });
/*
Copyright (c) 2008, Yahoo! Inc. All rights reserved.
Code licensed under the BSD License:
http://developer.yahoo.net/yui/license.txt
version: 2.6.0
*/
if (!YAHOO.util.DragDropMgr) {
    YAHOO.util.DragDropMgr = function() {
        var A = YAHOO.util.Event, B = YAHOO.util.Dom; return { useShim: false, _shimActive: false, _shimState: false, _debugShim: false, _createShim: function() { var C = document.createElement("div"); C.id = "yui-ddm-shim"; if (document.body.firstChild) { document.body.insertBefore(C, document.body.firstChild); } else { document.body.appendChild(C); } C.style.display = "none"; C.style.backgroundColor = "red"; C.style.position = "absolute"; C.style.zIndex = "99999"; B.setStyle(C, "opacity", "0"); this._shim = C; A.on(C, "mouseup", this.handleMouseUp, this, true); A.on(C, "mousemove", this.handleMouseMove, this, true); A.on(window, "scroll", this._sizeShim, this, true); }, _sizeShim: function() { if (this._shimActive) { var C = this._shim; C.style.height = B.getDocumentHeight() + "px"; C.style.width = B.getDocumentWidth() + "px"; C.style.top = "0"; C.style.left = "0"; } }, _activateShim: function() { if (this.useShim) { if (!this._shim) { this._createShim(); } this._shimActive = true; var C = this._shim, D = "0"; if (this._debugShim) { D = ".5"; } B.setStyle(C, "opacity", D); this._sizeShim(); C.style.display = "block"; } }, _deactivateShim: function() { this._shim.style.display = "none"; this._shimActive = false; }, _shim: null, ids: {}, handleIds: {}, dragCurrent: null, dragOvers: {}, deltaX: 0, deltaY: 0, preventDefault: true, stopPropagation: true, initialized: false, locked: false, interactionInfo: null, init: function() { this.initialized = true; }, POINT: 0, INTERSECT: 1, STRICT_INTERSECT: 2, mode: 0, _execOnAll: function(E, D) { for (var F in this.ids) { for (var C in this.ids[F]) { var G = this.ids[F][C]; if (!this.isTypeOfDD(G)) { continue; } G[E].apply(G, D); } } }, _onLoad: function() { this.init(); A.on(document, "mouseup", this.handleMouseUp, this, true); A.on(document, "mousemove", this.handleMouseMove, this, true); A.on(window, "unload", this._onUnload, this, true); A.on(window, "resize", this._onResize, this, true); }, _onResize: function(C) { this._execOnAll("resetConstraints", []); }, lock: function() { this.locked = true; }, unlock: function() { this.locked = false; }, isLocked: function() { return this.locked; }, locationCache: {}, useCache: true, clickPixelThresh: 3, clickTimeThresh: 1000, dragThreshMet: false, clickTimeout: null, startX: 0, startY: 0, fromTimeout: false, regDragDrop: function(D, C) { if (!this.initialized) { this.init(); } if (!this.ids[C]) { this.ids[C] = {}; } this.ids[C][D.id] = D; }, removeDDFromGroup: function(E, C) { if (!this.ids[C]) { this.ids[C] = {}; } var D = this.ids[C]; if (D && D[E.id]) { delete D[E.id]; } }, _remove: function(E) { for (var D in E.groups) { if (D) { var C = this.ids[D]; if (C && C[E.id]) { delete C[E.id]; } } } delete this.handleIds[E.id]; }, regHandle: function(D, C) { if (!this.handleIds[D]) { this.handleIds[D] = {}; } this.handleIds[D][C] = C; }, isDragDrop: function(C) { return (this.getDDById(C)) ? true : false; }, getRelated: function(H, D) { var G = []; for (var F in H.groups) { for (var E in this.ids[F]) { var C = this.ids[F][E]; if (!this.isTypeOfDD(C)) { continue; } if (!D || C.isTarget) { G[G.length] = C; } } } return G; }, isLegalTarget: function(G, F) { var D = this.getRelated(G, true); for (var E = 0, C = D.length; E < C; ++E) { if (D[E].id == F.id) { return true; } } return false; }, isTypeOfDD: function(C) { return (C && C.__ygDragDrop); }, isHandle: function(D, C) { return (this.handleIds[D] && this.handleIds[D][C]); }, getDDById: function(D) { for (var C in this.ids) { if (this.ids[C][D]) { return this.ids[C][D]; } } return null; }, handleMouseDown: function(E, D) { this.currentTarget = YAHOO.util.Event.getTarget(E); this.dragCurrent = D; var C = D.getEl(); this.startX = YAHOO.util.Event.getPageX(E); this.startY = YAHOO.util.Event.getPageY(E); this.deltaX = this.startX - C.offsetLeft; this.deltaY = this.startY - C.offsetTop; this.dragThreshMet = false; this.clickTimeout = setTimeout(function() { var F = YAHOO.util.DDM; F.startDrag(F.startX, F.startY); F.fromTimeout = true; }, this.clickTimeThresh); }, startDrag: function(C, E) { if (this.dragCurrent && this.dragCurrent.useShim) { this._shimState = this.useShim; this.useShim = true; } this._activateShim(); clearTimeout(this.clickTimeout); var D = this.dragCurrent; if (D && D.events.b4StartDrag) { D.b4StartDrag(C, E); D.fireEvent("b4StartDragEvent", { x: C, y: E }); } if (D && D.events.startDrag) { D.startDrag(C, E); D.fireEvent("startDragEvent", { x: C, y: E }); } this.dragThreshMet = true; }, handleMouseUp: function(C) { if (this.dragCurrent) { clearTimeout(this.clickTimeout); if (this.dragThreshMet) { if (this.fromTimeout) { this.fromTimeout = false; this.handleMouseMove(C); } this.fromTimeout = false; this.fireEvents(C, true); } else { } this.stopDrag(C); this.stopEvent(C); } }, stopEvent: function(C) { if (this.stopPropagation) { YAHOO.util.Event.stopPropagation(C); } if (this.preventDefault) { YAHOO.util.Event.preventDefault(C); } }, stopDrag: function(E, D) { var C = this.dragCurrent; if (C && !D) { if (this.dragThreshMet) { if (C.events.b4EndDrag) { C.b4EndDrag(E); C.fireEvent("b4EndDragEvent", { e: E }); } if (C.events.endDrag) { C.endDrag(E); C.fireEvent("endDragEvent", { e: E }); } } if (C.events.mouseUp) { C.onMouseUp(E); C.fireEvent("mouseUpEvent", { e: E }); } } if (this._shimActive) { this._deactivateShim(); if (this.dragCurrent && this.dragCurrent.useShim) { this.useShim = this._shimState; this._shimState = false; } } this.dragCurrent = null; this.dragOvers = {}; }, handleMouseMove: function(F) { var C = this.dragCurrent; if (C) { if (YAHOO.util.Event.isIE && !F.button) { this.stopEvent(F); return this.handleMouseUp(F); } else { if (F.clientX < 0 || F.clientY < 0) { } } if (!this.dragThreshMet) { var E = Math.abs(this.startX - YAHOO.util.Event.getPageX(F)); var D = Math.abs(this.startY - YAHOO.util.Event.getPageY(F)); if (E > this.clickPixelThresh || D > this.clickPixelThresh) { this.startDrag(this.startX, this.startY); } } if (this.dragThreshMet) { if (C && C.events.b4Drag) { C.b4Drag(F); C.fireEvent("b4DragEvent", { e: F }); } if (C && C.events.drag) { C.onDrag(F); C.fireEvent("dragEvent", { e: F }); } if (C) { this.fireEvents(F, false); } } this.stopEvent(F); } }, fireEvents: function(V, L) {
            var a = this.dragCurrent; if (!a || a.isLocked() || a.dragOnly) { return; } var N = YAHOO.util.Event.getPageX(V), M = YAHOO.util.Event.getPageY(V), P = new YAHOO.util.Point(N, M), K = a.getTargetCoord(P.x, P.y), F = a.getDragEl(), E = ["out", "over", "drop", "enter"], U = new YAHOO.util.Region(K.y, K.x + (F ? F.offsetWidth : 0), K.y + (F ? F.offsetHeight : 0), K.x), I = [], D = {}, Q = [], c = { outEvts: [], overEvts: [], dropEvts: [], enterEvts: [] }; for (var S in this.dragOvers) {
                var d = this.dragOvers[S]; if (!this.isTypeOfDD(d)) {
                    continue;
                } if (!this.isOverTarget(P, d, this.mode, U)) { c.outEvts.push(d); } I[S] = true; delete this.dragOvers[S];
            } for (var R in a.groups) { if ("string" != typeof R) { continue; } for (S in this.ids[R]) { var G = this.ids[R][S]; if (!this.isTypeOfDD(G)) { continue; } if (G.isTarget && !G.isLocked() && G != a) { if (this.isOverTarget(P, G, this.mode, U)) { D[R] = true; if (L) { c.dropEvts.push(G); } else { if (!I[G.id]) { c.enterEvts.push(G); } else { c.overEvts.push(G); } this.dragOvers[G.id] = G; } } } } } this.interactionInfo = { out: c.outEvts, enter: c.enterEvts, over: c.overEvts, drop: c.dropEvts, point: P, draggedRegion: U, sourceRegion: this.locationCache[a.id], validDrop: L }; for (var C in D) { Q.push(C); } if (L && !c.dropEvts.length) { this.interactionInfo.validDrop = false; if (a.events.invalidDrop) { a.onInvalidDrop(V); a.fireEvent("invalidDropEvent", { e: V }); } } for (S = 0; S < E.length; S++) { var Y = null; if (c[E[S] + "Evts"]) { Y = c[E[S] + "Evts"]; } if (Y && Y.length) { var H = E[S].charAt(0).toUpperCase() + E[S].substr(1), X = "onDrag" + H, J = "b4Drag" + H, O = "drag" + H + "Event", W = "drag" + H; if (this.mode) { if (a.events[J]) { a[J](V, Y, Q); a.fireEvent(J + "Event", { event: V, info: Y, group: Q }); } if (a.events[W]) { a[X](V, Y, Q); a.fireEvent(O, { event: V, info: Y, group: Q }); } } else { for (var Z = 0, T = Y.length; Z < T; ++Z) { if (a.events[J]) { a[J](V, Y[Z].id, Q[0]); a.fireEvent(J + "Event", { event: V, info: Y[Z].id, group: Q[0] }); } if (a.events[W]) { a[X](V, Y[Z].id, Q[0]); a.fireEvent(O, { event: V, info: Y[Z].id, group: Q[0] }); } } } } } 
        }, getBestMatch: function(E) { var G = null; var D = E.length; if (D == 1) { G = E[0]; } else { for (var F = 0; F < D; ++F) { var C = E[F]; if (this.mode == this.INTERSECT && C.cursorIsOver) { G = C; break; } else { if (!G || !G.overlap || (C.overlap && G.overlap.getArea() < C.overlap.getArea())) { G = C; } } } } return G; }, refreshCache: function(D) { var F = D || this.ids; for (var C in F) { if ("string" != typeof C) { continue; } for (var E in this.ids[C]) { var G = this.ids[C][E]; if (this.isTypeOfDD(G)) { var H = this.getLocation(G); if (H) { this.locationCache[G.id] = H; } else { delete this.locationCache[G.id]; } } } } }, verifyEl: function(D) { try { if (D) { var C = D.offsetParent; if (C) { return true; } } } catch (E) { } return false; }, getLocation: function(H) { if (!this.isTypeOfDD(H)) { return null; } var F = H.getEl(), K, E, D, M, L, N, C, J, G; try { K = YAHOO.util.Dom.getXY(F); } catch (I) { } if (!K) { return null; } E = K[0]; D = E + F.offsetWidth; M = K[1]; L = M + F.offsetHeight; N = M - H.padding[0]; C = D + H.padding[1]; J = L + H.padding[2]; G = E - H.padding[3]; return new YAHOO.util.Region(N, C, J, G); }, isOverTarget: function(K, C, E, F) { var G = this.locationCache[C.id]; if (!G || !this.useCache) { G = this.getLocation(C); this.locationCache[C.id] = G; } if (!G) { return false; } C.cursorIsOver = G.contains(K); var J = this.dragCurrent; if (!J || (!E && !J.constrainX && !J.constrainY)) { return C.cursorIsOver; } C.overlap = null; if (!F) { var H = J.getTargetCoord(K.x, K.y); var D = J.getDragEl(); F = new YAHOO.util.Region(H.y, H.x + D.offsetWidth, H.y + D.offsetHeight, H.x); } var I = F.intersect(G); if (I) { C.overlap = I; return (E) ? true : C.cursorIsOver; } else { return false; } }, _onUnload: function(D, C) { this.unregAll(); }, unregAll: function() { if (this.dragCurrent) { this.stopDrag(); this.dragCurrent = null; } this._execOnAll("unreg", []); this.ids = {}; }, elementCache: {}, getElWrapper: function(D) { var C = this.elementCache[D]; if (!C || !C.el) { C = this.elementCache[D] = new this.ElementWrapper(YAHOO.util.Dom.get(D)); } return C; }, getElement: function(C) { return YAHOO.util.Dom.get(C); }, getCss: function(D) { var C = YAHOO.util.Dom.get(D); return (C) ? C.style : null; }, ElementWrapper: function(C) { this.el = C || null; this.id = this.el && C.id; this.css = this.el && C.style; }, getPosX: function(C) { return YAHOO.util.Dom.getX(C); }, getPosY: function(C) { return YAHOO.util.Dom.getY(C); }, swapNode: function(E, C) { if (E.swapNode) { E.swapNode(C); } else { var F = C.parentNode; var D = C.nextSibling; if (D == E) { F.insertBefore(E, C); } else { if (C == E.nextSibling) { F.insertBefore(C, E); } else { E.parentNode.replaceChild(C, E); F.insertBefore(E, D); } } } }, getScroll: function() { var E, C, F = document.documentElement, D = document.body; if (F && (F.scrollTop || F.scrollLeft)) { E = F.scrollTop; C = F.scrollLeft; } else { if (D) { E = D.scrollTop; C = D.scrollLeft; } else { } } return { top: E, left: C }; }, getStyle: function(D, C) { return YAHOO.util.Dom.getStyle(D, C); }, getScrollTop: function() { return this.getScroll().top; }, getScrollLeft: function() { return this.getScroll().left; }, moveToEl: function(C, E) { var D = YAHOO.util.Dom.getXY(E); YAHOO.util.Dom.setXY(C, D); }, getClientHeight: function() { return YAHOO.util.Dom.getViewportHeight(); }, getClientWidth: function() { return YAHOO.util.Dom.getViewportWidth(); }, numericSort: function(D, C) { return (D - C); }, _timeoutCount: 0, _addListeners: function() { var C = YAHOO.util.DDM; if (YAHOO.util.Event && document) { C._onLoad(); } else { if (C._timeoutCount > 2000) { } else { setTimeout(C._addListeners, 10); if (document && document.body) { C._timeoutCount += 1; } } } }, handleWasClicked: function(C, E) { if (this.isHandle(E, C.id)) { return true; } else { var D = C.parentNode; while (D) { if (this.isHandle(E, D.id)) { return true; } else { D = D.parentNode; } } } return false; } 
        };
    } (); YAHOO.util.DDM = YAHOO.util.DragDropMgr; YAHOO.util.DDM._addListeners();
} (function() {
    var A = YAHOO.util.Event; var B = YAHOO.util.Dom; YAHOO.util.DragDrop = function(E, C, D) { if (E) { this.init(E, C, D); } }; YAHOO.util.DragDrop.prototype = { events: null, on: function() { this.subscribe.apply(this, arguments); }, id: null, config: null, dragElId: null, handleElId: null, invalidHandleTypes: null, invalidHandleIds: null, invalidHandleClasses: null, startPageX: 0, startPageY: 0, groups: null, locked: false, lock: function() { this.locked = true; }, unlock: function() { this.locked = false; }, isTarget: true, padding: null, dragOnly: false, useShim: false, _domRef: null, __ygDragDrop: true, constrainX: false, constrainY: false, minX: 0, maxX: 0, minY: 0, maxY: 0, deltaX: 0, deltaY: 0, maintainOffset: false, xTicks: null, yTicks: null, primaryButtonOnly: true, available: false, hasOuterHandles: false, cursorIsOver: false, overlap: null, b4StartDrag: function(C, D) { }, startDrag: function(C, D) { }, b4Drag: function(C) { }, onDrag: function(C) { }, onDragEnter: function(C, D) { }, b4DragOver: function(C) { }, onDragOver: function(C, D) { }, b4DragOut: function(C) { }, onDragOut: function(C, D) { }, b4DragDrop: function(C) { }, onDragDrop: function(C, D) { }, onInvalidDrop: function(C) { }, b4EndDrag: function(C) { }, endDrag: function(C) { }, b4MouseDown: function(C) { }, onMouseDown: function(C) { }, onMouseUp: function(C) { }, onAvailable: function() { }, getEl: function() {
        if (!this._domRef) {
            this._domRef = B.get(this.id);
        } return this._domRef;
    }, getDragEl: function() { return B.get(this.dragElId); }, init: function(F, C, D) { this.initTarget(F, C, D); A.on(this._domRef || this.id, "mousedown", this.handleMouseDown, this, true); for (var E in this.events) { this.createEvent(E + "Event"); } }, initTarget: function(E, C, D) { this.config = D || {}; this.events = {}; this.DDM = YAHOO.util.DDM; this.groups = {}; if (typeof E !== "string") { this._domRef = E; E = B.generateId(E); } this.id = E; this.addToGroup((C) ? C : "default"); this.handleElId = E; A.onAvailable(E, this.handleOnAvailable, this, true); this.setDragElId(E); this.invalidHandleTypes = { A: "A" }; this.invalidHandleIds = {}; this.invalidHandleClasses = []; this.applyConfig(); }, applyConfig: function() { this.events = { mouseDown: true, b4MouseDown: true, mouseUp: true, b4StartDrag: true, startDrag: true, b4EndDrag: true, endDrag: true, drag: true, b4Drag: true, invalidDrop: true, b4DragOut: true, dragOut: true, dragEnter: true, b4DragOver: true, dragOver: true, b4DragDrop: true, dragDrop: true }; if (this.config.events) { for (var C in this.config.events) { if (this.config.events[C] === false) { this.events[C] = false; } } } this.padding = this.config.padding || [0, 0, 0, 0]; this.isTarget = (this.config.isTarget !== false); this.maintainOffset = (this.config.maintainOffset); this.primaryButtonOnly = (this.config.primaryButtonOnly !== false); this.dragOnly = ((this.config.dragOnly === true) ? true : false); this.useShim = ((this.config.useShim === true) ? true : false); }, handleOnAvailable: function() { this.available = true; this.resetConstraints(); this.onAvailable(); }, setPadding: function(E, C, F, D) { if (!C && 0 !== C) { this.padding = [E, E, E, E]; } else { if (!F && 0 !== F) { this.padding = [E, C, E, C]; } else { this.padding = [E, C, F, D]; } } }, setInitPosition: function(F, E) { var G = this.getEl(); if (!this.DDM.verifyEl(G)) { if (G && G.style && (G.style.display == "none")) { } else { } return; } var D = F || 0; var C = E || 0; var H = B.getXY(G); this.initPageX = H[0] - D; this.initPageY = H[1] - C; this.lastPageX = H[0]; this.lastPageY = H[1]; this.setStartPosition(H); }, setStartPosition: function(D) { var C = D || B.getXY(this.getEl()); this.deltaSetXY = null; this.startPageX = C[0]; this.startPageY = C[1]; }, addToGroup: function(C) { this.groups[C] = true; this.DDM.regDragDrop(this, C); }, removeFromGroup: function(C) { if (this.groups[C]) { delete this.groups[C]; } this.DDM.removeDDFromGroup(this, C); }, setDragElId: function(C) { this.dragElId = C; }, setHandleElId: function(C) { if (typeof C !== "string") { C = B.generateId(C); } this.handleElId = C; this.DDM.regHandle(this.id, C); }, setOuterHandleElId: function(C) { if (typeof C !== "string") { C = B.generateId(C); } A.on(C, "mousedown", this.handleMouseDown, this, true); this.setHandleElId(C); this.hasOuterHandles = true; }, unreg: function() { A.removeListener(this.id, "mousedown", this.handleMouseDown); this._domRef = null; this.DDM._remove(this); }, isLocked: function() { return (this.DDM.isLocked() || this.locked); }, handleMouseDown: function(J, I) { var D = J.which || J.button; if (this.primaryButtonOnly && D > 1) { return; } if (this.isLocked()) { return; } var C = this.b4MouseDown(J), F = true; if (this.events.b4MouseDown) { F = this.fireEvent("b4MouseDownEvent", J); } var E = this.onMouseDown(J), H = true; if (this.events.mouseDown) { H = this.fireEvent("mouseDownEvent", J); } if ((C === false) || (E === false) || (F === false) || (H === false)) { return; } this.DDM.refreshCache(this.groups); var G = new YAHOO.util.Point(A.getPageX(J), A.getPageY(J)); if (!this.hasOuterHandles && !this.DDM.isOverTarget(G, this)) { } else { if (this.clickValidator(J)) { this.setStartPosition(); this.DDM.handleMouseDown(J, this); this.DDM.stopEvent(J); } else { } } }, clickValidator: function(D) { var C = YAHOO.util.Event.getTarget(D); return (this.isValidHandleChild(C) && (this.id == this.handleElId || this.DDM.handleWasClicked(C, this.id))); }, getTargetCoord: function(E, D) { var C = E - this.deltaX; var F = D - this.deltaY; if (this.constrainX) { if (C < this.minX) { C = this.minX; } if (C > this.maxX) { C = this.maxX; } } if (this.constrainY) { if (F < this.minY) { F = this.minY; } if (F > this.maxY) { F = this.maxY; } } C = this.getTick(C, this.xTicks); F = this.getTick(F, this.yTicks); return { x: C, y: F }; }, addInvalidHandleType: function(C) { var D = C.toUpperCase(); this.invalidHandleTypes[D] = D; }, addInvalidHandleId: function(C) { if (typeof C !== "string") { C = B.generateId(C); } this.invalidHandleIds[C] = C; }, addInvalidHandleClass: function(C) { this.invalidHandleClasses.push(C); }, removeInvalidHandleType: function(C) { var D = C.toUpperCase(); delete this.invalidHandleTypes[D]; }, removeInvalidHandleId: function(C) { if (typeof C !== "string") { C = B.generateId(C); } delete this.invalidHandleIds[C]; }, removeInvalidHandleClass: function(D) { for (var E = 0, C = this.invalidHandleClasses.length; E < C; ++E) { if (this.invalidHandleClasses[E] == D) { delete this.invalidHandleClasses[E]; } } }, isValidHandleChild: function(F) { var E = true; var H; try { H = F.nodeName.toUpperCase(); } catch (G) { H = F.nodeName; } E = E && !this.invalidHandleTypes[H]; E = E && !this.invalidHandleIds[F.id]; for (var D = 0, C = this.invalidHandleClasses.length; E && D < C; ++D) { E = !B.hasClass(F, this.invalidHandleClasses[D]); } return E; }, setXTicks: function(F, C) { this.xTicks = []; this.xTickSize = C; var E = {}; for (var D = this.initPageX; D >= this.minX; D = D - C) { if (!E[D]) { this.xTicks[this.xTicks.length] = D; E[D] = true; } } for (D = this.initPageX; D <= this.maxX; D = D + C) { if (!E[D]) { this.xTicks[this.xTicks.length] = D; E[D] = true; } } this.xTicks.sort(this.DDM.numericSort); }, setYTicks: function(F, C) { this.yTicks = []; this.yTickSize = C; var E = {}; for (var D = this.initPageY; D >= this.minY; D = D - C) { if (!E[D]) { this.yTicks[this.yTicks.length] = D; E[D] = true; } } for (D = this.initPageY; D <= this.maxY; D = D + C) { if (!E[D]) { this.yTicks[this.yTicks.length] = D; E[D] = true; } } this.yTicks.sort(this.DDM.numericSort); }, setXConstraint: function(E, D, C) { this.leftConstraint = parseInt(E, 10); this.rightConstraint = parseInt(D, 10); this.minX = this.initPageX - this.leftConstraint; this.maxX = this.initPageX + this.rightConstraint; if (C) { this.setXTicks(this.initPageX, C); } this.constrainX = true; }, clearConstraints: function() { this.constrainX = false; this.constrainY = false; this.clearTicks(); }, clearTicks: function() { this.xTicks = null; this.yTicks = null; this.xTickSize = 0; this.yTickSize = 0; }, setYConstraint: function(C, E, D) {
        this.topConstraint = parseInt(C, 10); this.bottomConstraint = parseInt(E, 10); this.minY = this.initPageY - this.topConstraint; this.maxY = this.initPageY + this.bottomConstraint; if (D) {
            this.setYTicks(this.initPageY, D);
        } this.constrainY = true;
    }, resetConstraints: function() { if (this.initPageX || this.initPageX === 0) { var D = (this.maintainOffset) ? this.lastPageX - this.initPageX : 0; var C = (this.maintainOffset) ? this.lastPageY - this.initPageY : 0; this.setInitPosition(D, C); } else { this.setInitPosition(); } if (this.constrainX) { this.setXConstraint(this.leftConstraint, this.rightConstraint, this.xTickSize); } if (this.constrainY) { this.setYConstraint(this.topConstraint, this.bottomConstraint, this.yTickSize); } }, getTick: function(I, F) { if (!F) { return I; } else { if (F[0] >= I) { return F[0]; } else { for (var D = 0, C = F.length; D < C; ++D) { var E = D + 1; if (F[E] && F[E] >= I) { var H = I - F[D]; var G = F[E] - I; return (G > H) ? F[D] : F[E]; } } return F[F.length - 1]; } } }, toString: function() { return ("DragDrop " + this.id); } 
    }; YAHOO.augment(YAHOO.util.DragDrop, YAHOO.util.EventProvider);
})(); YAHOO.util.DD = function(C, A, B) { if (C) { this.init(C, A, B); } }; YAHOO.extend(YAHOO.util.DD, YAHOO.util.DragDrop, { scroll: true, autoOffset: function(C, B) { var A = C - this.startPageX; var D = B - this.startPageY; this.setDelta(A, D); }, setDelta: function(B, A) { this.deltaX = B; this.deltaY = A; }, setDragElPos: function(C, B) { var A = this.getDragEl(); this.alignElWithMouse(A, C, B); }, alignElWithMouse: function(C, G, F) { var E = this.getTargetCoord(G, F); if (!this.deltaSetXY) { var H = [E.x, E.y]; YAHOO.util.Dom.setXY(C, H); var D = parseInt(YAHOO.util.Dom.getStyle(C, "left"), 10); var B = parseInt(YAHOO.util.Dom.getStyle(C, "top"), 10); this.deltaSetXY = [D - E.x, B - E.y]; } else { YAHOO.util.Dom.setStyle(C, "left", (E.x + this.deltaSetXY[0]) + "px"); YAHOO.util.Dom.setStyle(C, "top", (E.y + this.deltaSetXY[1]) + "px"); } this.cachePosition(E.x, E.y); var A = this; setTimeout(function() { A.autoScroll.call(A, E.x, E.y, C.offsetHeight, C.offsetWidth); }, 0); }, cachePosition: function(B, A) { if (B) { this.lastPageX = B; this.lastPageY = A; } else { var C = YAHOO.util.Dom.getXY(this.getEl()); this.lastPageX = C[0]; this.lastPageY = C[1]; } }, autoScroll: function(J, I, E, K) { if (this.scroll) { var L = this.DDM.getClientHeight(); var B = this.DDM.getClientWidth(); var N = this.DDM.getScrollTop(); var D = this.DDM.getScrollLeft(); var H = E + I; var M = K + J; var G = (L + N - I - this.deltaY); var F = (B + D - J - this.deltaX); var C = 40; var A = (document.all) ? 80 : 30; if (H > L && G < C) { window.scrollTo(D, N + A); } if (I < N && N > 0 && I - N < C) { window.scrollTo(D, N - A); } if (M > B && F < C) { window.scrollTo(D + A, N); } if (J < D && D > 0 && J - D < C) { window.scrollTo(D - A, N); } } }, applyConfig: function() { YAHOO.util.DD.superclass.applyConfig.call(this); this.scroll = (this.config.scroll !== false); }, b4MouseDown: function(A) { this.setStartPosition(); this.autoOffset(YAHOO.util.Event.getPageX(A), YAHOO.util.Event.getPageY(A)); }, b4Drag: function(A) { this.setDragElPos(YAHOO.util.Event.getPageX(A), YAHOO.util.Event.getPageY(A)); }, toString: function() { return ("DD " + this.id); } }); YAHOO.util.DDProxy = function(C, A, B) { if (C) { this.init(C, A, B); this.initFrame(); } }; YAHOO.util.DDProxy.dragElId = "ygddfdiv"; YAHOO.extend(YAHOO.util.DDProxy, YAHOO.util.DD, { resizeFrame: true, centerFrame: false, createFrame: function() { var B = this, A = document.body; if (!A || !A.firstChild) { setTimeout(function() { B.createFrame(); }, 50); return; } var G = this.getDragEl(), E = YAHOO.util.Dom; if (!G) { G = document.createElement("div"); G.id = this.dragElId; var D = G.style; D.position = "absolute"; D.visibility = "hidden"; D.cursor = "move"; D.border = "2px solid #aaa"; D.zIndex = 999; D.height = "25px"; D.width = "25px"; var C = document.createElement("div"); E.setStyle(C, "height", "100%"); E.setStyle(C, "width", "100%"); E.setStyle(C, "background-color", "#ccc"); E.setStyle(C, "opacity", "0"); G.appendChild(C); if (YAHOO.env.ua.ie) { var F = document.createElement("iframe"); F.setAttribute("src", "javascript: false;"); F.setAttribute("scrolling", "no"); F.setAttribute("frameborder", "0"); G.insertBefore(F, G.firstChild); E.setStyle(F, "height", "100%"); E.setStyle(F, "width", "100%"); E.setStyle(F, "position", "absolute"); E.setStyle(F, "top", "0"); E.setStyle(F, "left", "0"); E.setStyle(F, "opacity", "0"); E.setStyle(F, "zIndex", "-1"); E.setStyle(F.nextSibling, "zIndex", "2"); } A.insertBefore(G, A.firstChild); } }, initFrame: function() { this.createFrame(); }, applyConfig: function() { YAHOO.util.DDProxy.superclass.applyConfig.call(this); this.resizeFrame = (this.config.resizeFrame !== false); this.centerFrame = (this.config.centerFrame); this.setDragElId(this.config.dragElId || YAHOO.util.DDProxy.dragElId); }, showFrame: function(E, D) { var C = this.getEl(); var A = this.getDragEl(); var B = A.style; this._resizeProxy(); if (this.centerFrame) { this.setDelta(Math.round(parseInt(B.width, 10) / 2), Math.round(parseInt(B.height, 10) / 2)); } this.setDragElPos(E, D); YAHOO.util.Dom.setStyle(A, "visibility", "visible"); }, _resizeProxy: function() { if (this.resizeFrame) { var H = YAHOO.util.Dom; var B = this.getEl(); var C = this.getDragEl(); var G = parseInt(H.getStyle(C, "borderTopWidth"), 10); var I = parseInt(H.getStyle(C, "borderRightWidth"), 10); var F = parseInt(H.getStyle(C, "borderBottomWidth"), 10); var D = parseInt(H.getStyle(C, "borderLeftWidth"), 10); if (isNaN(G)) { G = 0; } if (isNaN(I)) { I = 0; } if (isNaN(F)) { F = 0; } if (isNaN(D)) { D = 0; } var E = Math.max(0, B.offsetWidth - I - D); var A = Math.max(0, B.offsetHeight - G - F); H.setStyle(C, "width", E + "px"); H.setStyle(C, "height", A + "px"); } }, b4MouseDown: function(B) { this.setStartPosition(); var A = YAHOO.util.Event.getPageX(B); var C = YAHOO.util.Event.getPageY(B); this.autoOffset(A, C); }, b4StartDrag: function(A, B) { this.showFrame(A, B); }, b4EndDrag: function(A) { YAHOO.util.Dom.setStyle(this.getDragEl(), "visibility", "hidden"); }, endDrag: function(D) { var C = YAHOO.util.Dom; var B = this.getEl(); var A = this.getDragEl(); C.setStyle(A, "visibility", ""); C.setStyle(B, "visibility", "hidden"); YAHOO.util.DDM.moveToEl(B, A); C.setStyle(A, "visibility", "hidden"); C.setStyle(B, "visibility", ""); }, toString: function() { return ("DDProxy " + this.id); } }); YAHOO.util.DDTarget = function(C, A, B) { if (C) { this.initTarget(C, A, B); } }; YAHOO.extend(YAHOO.util.DDTarget, YAHOO.util.DragDrop, { toString: function() { return ("DDTarget " + this.id); } }); YAHOO.register("dragdrop", YAHOO.util.DragDropMgr, { version: "2.6.0", build: "1321" });
function MMLineTracker(_map, _posList) {
    //////////////////////////////
    // Initialize				//
    //////////////////////////////
    this.init = function(map, posList) {

        this.mmmap = map;
        this.positionList = posList;

        this.id;
        this.trackerObject;
        this.currentSection = -1;
        this.step = 1.0;
        this.lastSection = this.positionList.length - 2;

        this.lon = this.positionList[0][0];
        this.lat = this.positionList[0][1];
        this.xVector = 0;
        this.yVector = 0;

        this.refreshTime = 111;
        this.imgExt = '.png';
        this.imgExtOld = '.gif';
        // IE6
        /*@cc_on
        @if (@_jscript_version <= 5.6)
        this.imgExt = this.imgExtOld,
        @end
        @*/
		this.setSpeed();
        this.setImage('http://mmmap15.longdo.com//mmmap/images/line/tracker', 16, 16);
    };

    //////////////////////////////
    // Public Event				//
    //////////////////////////////
    this.onFinalize;

    //////////////////////////////
    // Setter					//
    //////////////////////////////
    /**
    * speed in milli-degree/s (~100m/s)
    */
    this.setSpeed = function(speed) {
        if (isNaN(speed)) {
            speed = 8192 / Math.pow(2, this.mmmap.getZoom());
        }
        this.speed = speed * this.refreshTime / 1E6;
    };

    this.setImage = function(imgPre, offsetX, offsetY) {
        this.imgPre = imgPre;
        this.offsetX = offsetX;
        this.offsetY = offsetY;
    };

    //////////////////////////////
    // Public Method			//
    //////////////////////////////
    this.start = function() {
        this.trackerImg = this.imgPre + '0' + this.imgExt;
        this.trackerObject = document.createElement('img');
        this.trackerObject.src = this.trackerImg;
        this.id = this.mmmap.drawCustomDiv(this.trackerObject, this.lat, this.lon, '', { 'centerOffsetX': this.offsetX + 'px',
            'centerOffsetY': this.offsetY + 'px'
        });
        mmhelper.ensureVisibility(this.lat, this.lon, 20);
        this.intervalId = setInterval('mmlinetracker.update()', this.refreshTime);
    };

    this.stop = function() {
        clearInterval(this.intervalId);
        this.mmmap.removeCustomDivs(this.id);
    };

    //////////////////////////////
    // Private Method			//
    //////////////////////////////
    this.draw = function() {
        var trackerDiv = this.mmmap.getCustomDivHolder(this.id);
        trackerDiv.longitude = this.lon;
        trackerDiv.latitude = this.lat;
        this.trackerObject.src = this.trackerImg;
        this.mmmap.redrawCustomDivs();
        mmhelper.ensureVisibility(this.lat, this.lon, 20);
    };

    this.update = function() {
        this.lon += this.xVector;
        this.lat += this.yVector;
        this.step--;

        if (this.step < 1.0) {
            var singleStep;
            while (this.step < 1.0) {
                if (this.currentSection >= this.lastSection) {
                    this.lon = this.positionList[this.positionList.length - 1][0];
                    this.lat = this.positionList[this.positionList.length - 1][1];
                    this.trackerImg = this.imgPre + '0' + this.imgExt;
                    this.draw();
                    clearInterval(this.intervalId);
                    setTimeout('mmlinetracker.finalize()', 3000);
                    return;
                }
                this.currentSection++;
                this.xVector = this.positionList[this.currentSection + 1][0] - this.positionList[this.currentSection][0];
                this.yVector = this.positionList[this.currentSection + 1][1] - this.positionList[this.currentSection][1];
                singleStep = mmhelper.vectorSize(this.xVector, this.yVector) / this.speed;
                this.step += singleStep;
            }
            this.xVector /= singleStep;
            this.yVector /= singleStep;
            this.trackerImg = this.imgPre + this.directionCode() + this.imgExt;

            var startStep = (1.0 - (this.step - singleStep));
            this.step -= startStep;
            this.lon = this.positionList[this.currentSection][0] + (this.xVector * startStep);
            this.lat = this.positionList[this.currentSection][1] + (this.yVector * startStep);
        }

        this.draw();
    };

    this.directionCode = function() {
        var angle = Math.atan2(this.yVector, this.xVector);
        if (angle > 2.7489) return 5;
        if (angle > 1.9635) return 4;
        if (angle > 1.1781) return 3;
        if (angle > 0.3927) return 2;
        if (angle > -0.3927) return 1;
        if (angle > -1.1781) return 8;
        if (angle > -1.9635) return 7;
        if (angle > -2.7489) return 6;
        return 5;
    }

    this.finalize = function() {
        if (this.currentSection < this.lastSection) return;
        this.stop();
        this.onFinalize();
    };

    this.init(_map, _posList);
    mmlinetracker = this;
}

function MMLinePointer(_map, _posList) {
    //////////////////////////////
    // Initialize				//
    //////////////////////////////
    this.init = function(map, posList) {
        this.mmmap = map;
        this.positionList = posList;

        this.id = -1;

        this.maxShowDistance = 15;
        this.imgExt = '.png';
        this.imgExtOld = '.gif';
        // IE6
        /*@cc_on
        @if (@_jscript_version <= 5.6)
        this.imgExt = this.imgExtOld,
        @end
        @*/
		this.setImage('http://mmmap15.longdo.com//mmmap/images/line/pointer', 8, 8);
    }
    //////////////////////////////
    // Public Event				//
    //////////////////////////////
    this.onDrop;
    this.onMove;

    //////////////////////////////
    // Setter					//
    //////////////////////////////
    this.setImage = function(imgPre, offsetX, offsetY) {
        this.imgPre = imgPre;
        this.offsetX = offsetX;
        this.offsetY = offsetY;
    }

    //////////////////////////////
    // Public Method			//
    //////////////////////////////
    this.show = function() {
        this.oldMapDivMousemove = mymap.onmousemove;
        mymap.onmousemove = this.update;
    };

    this.hide = function() {
        try {
            mymap.onmousemove = this.oldMapDivMousemove;
        } catch (err) { }

        if (this.id < 0) return;
        this.mmmap.removeCustomDivs(this.id);
        this.id = -1;
    };

    //////////////////////////////
    // Private Method			//
    //////////////////////////////
    this.update = function() {
        if (document.getElementById('context_menu').style.visibility == 'visible') return;

        var lat = mmlinepointer.mmmap.mouseCursorLat();
        var lon = mmlinepointer.mmmap.mouseCursorLong();
        var resolution = Math.pow(2, mmlinepointer.mmmap.getZoom());

        var posList = mmlinepointer.positionList;
        var tempPoint;
        var tempDist;
        var minDist = Number.MAX_VALUE;
        var x;
        var y;
        var segment;

        for (var i = 1; i < posList.length; i++) {
            tempPoint = mmhelper.findClosestPointOnLine(posList[i - 1][0], posList[i - 1][1], posList[i][0], posList[i][1], lon, lat);
            tempDist = mmhelper.approxDistancePixel(lat, lon, tempPoint[1], tempPoint[0], resolution);
            if (tempDist < minDist) {
                minDist = tempDist;
                x = tempPoint[0];
                y = tempPoint[1];
                segment = i - 1;
            }
        }
        if (minDist > mmlinepointer.maxShowDistance) {
            if (mmlinepointer.id >= 0) {
                mmlinepointer.mmmap.removeCustomDivs(mmlinepointer.id);
                mmlinepointer.id = -1;
            }
            return;
        }
        if (mmlinepointer.id < 0) {
            var pointerObject = document.createElement('img');
            pointerObject.src = mmlinepointer.imgPre + mmlinepointer.imgExt;
            pointerObject.style.cursor = 'pointer';
            pointerObject.style.zIndex = '-2';
            pointerObject.segment = segment;
            pointerObject.onmousedown = mmlinepointer.pointerFunction;
            mmlinepointer.id = mmlinepointer.mmmap.drawCustomDiv(pointerObject, y, x, '',
				{ 'centerOffsetX': mmlinepointer.offsetX + 'px', 'centerOffsetY': mmlinepointer.offsetY + 'px' });
        } else {
            var pointerDiv = mmlinepointer.mmmap.getCustomDivHolder(mmlinepointer.id);
            pointerDiv.longitude = x;
            pointerDiv.latitude = y;
            mmlinepointer.mmmap.redrawCustomDivs();
        }

        if (mmlinepointer.onMove) {
            var pointerDiv = mmlinepointer.mmmap.getCustomDivHolder(mmlinepointer.id);
            mmlinepointer.onMove(segment, y, x);
        }
    };

    this.pointerFunction = function(event) {
        event = mmhelper.eventIE2W3C(event);
        if (!mmhelper.isLeftClick(event)) {
            event.cancelBubble = true;
            return false;
        }

        var style = event.target.style;
        var oldLeft = parseInt(style.left.replace('px', ''));
        var oldTop = parseInt(style.top.replace('px', ''));
        var downX = event.clientX;
        var downY = event.clientY;

        var moving = function(event2) {
            event2 = mmhelper.eventIE2W3C(event2);
            style.cursor = 'move';
            style.left = (oldLeft + event2.clientX - downX) + 'px';
            style.top = (oldTop + event2.clientY - downY) + 'px';

            event2.cancelBubble = true;
            return false;
        };

        var moved = function(event2) {
            event2 = mmhelper.eventIE2W3C(event2);

            mmlinepointer.mmmap.removeCustomDivs(mmlinepointer.id);

            if (mmlinepointer.onDrop) {
                var resolution = Math.pow(2, mmlinepointer.mmmap.getZoom());
                mmlinepointer.onDrop(event.target.segment, pointToLat(oldTop + event2.clientY - downY + mmlinepointer.offsetY, resolution),
					pointToLong(oldLeft + event2.clientX - downX + mmlinepointer.offsetX, resolution));
            }

            mymaparea.onmousemove = mmlinepointer.mmmap.do_move;
            mymaparea.onmouseup = mmlinepointer.mmmap.do_mu;
            mmlinepointer.mmmap.do_mu(event2);
            event2.cancelBubble = true;
            style.cursor = 'pointer';
            return false;
        };

        mymaparea.onmousemove = moving;
        mymaparea.onmouseup = function(event2) {
            event2 = mmhelper.eventIE2W3C(event2);
            if (!mmhelper.isLeftClick(event2)) {
                event2.cancelBubble = true;
                return false;
            }
            return moved(event2);
        };

        event.target.parentNode.ondrag = moving;
        event.target.parentNode.ondragend = moved;
        return false;
    };

    this.init(_map, _posList);
    mmlinepointer = this;
}

function MMHelper() {
    //////////////////////////////
    // Initialize				//
    //////////////////////////////
    this.init = function() {
        String.prototype.trim = function() {
            return this.replace(/^\s*/, '').replace(/\s*$/, '');
        };

        // IE
        if (!Array.indexOf) {
            Array.prototype.indexOf = function(obj) {
                for (var i = 0; i < this.length; i++) {
                    if (this[i] == obj) return i;
                }
                return -1;
            }
        }
    }

    //////////////////////////////
    // Public Method			//
    //////////////////////////////
    this.findClosestPointOnLine = function(x1, y1, x2, y2, x3, y3) { // 1, 2 = line; 3 = point 
        var dx = x2 - x1;
        var dy = y2 - y1;
        var u = ((x3 - x1) * dx + (y3 - y1) * dy) / ((dx * dx) + (dy * dy));

        if (u < 0) return [x1, y1];
        if (u > 1) return [x2, y2];
        return [x1 + (u * dx), y1 + (u * dy)];
    };

    this.approxDistancePixel = function(lat1, lon1, lat2, lon2, resolution) {
        return Math.abs(latToPoint(lat1, resolution) - latToPoint(lat2, resolution)) +
			Math.abs(longToPoint(lon1, resolution) - longToPoint(lon2, resolution));
    };

    this.vectorSize = function(x, y) {
        return Math.sqrt((x * x) + (y * y));
    };

    this.isInBound = function(x, y, left, top, width, height, resolution) {
        return x >= left && x <= (left + width) && y >= top && y <= (top + height);
    };

    this.ensureVisibility = function(lat, lon, offset) {
        // FIXME: Remove mapoffset if define in *ToPoint
        var x = longToPoint(lon, resolution) - mmmap.mapoffset.x;
        var y = latToPoint(lat, resolution) - mmmap.mapoffset.y;
        if (this.isInBound(x, y, -parseInt(mymap.style.left.replace('px', '')) + offset, -parseInt(mymap.style.top.replace('px', '')) +
			offset, parseInt(mymaparea.style.width.replace('px', '')) - (2 * offset), parseInt(mymaparea.style.height.replace('px', '')) -
			(2 * offset))) return false;

        mmmap.moveTo(lat, lon);
        return true;
    };

    this.ensureVisibilityZoom = function(lat1, lon1, lat2, lon2, offset) {
        var res = resolution * 2;
        var latMean = (lat1 + lat2) / 2;
        var lonMean = (lon1 + lon2) / 2;

        while (this.ensureVisibility(lat1, lon1, offset) || this.ensureVisibility(lat2, lon2, offset)) {
            mmmap.setCenter(latMean, lonMean, res / 2);
            res = resolution;
        }
    };

    this.eventIE2W3C = function(event) {
        if (event) return event;
        event = window.event;
        event.target = event.srcElement;
        if (event.button == 1) { // Left click
            event.which = 1;
        } else if (event.button == 4) { // Middle click
            event.which = 2;
        } else if (event.button == 2) { // Right click
            event.which = 3;
        }
        return event;
    };

    this.isLeftClick = function(event) {
        return event.which == 1;
    };

    this.isMiddleClick = function(event) {
        return event.which == 2;
    };

    this.isRightClick = function(event) {
        return event.which == 3;
    };

    this.init();
    mmhelper = this;
}
new MMHelper();

var mylang = "th";

function MMLine(mmmap, mode, canvas) {
    document.pointdraging = false;
    this.id = 0;
    this.rulerButtonFn = false;
    this.mmmap = mmmap;
    this.canvas = canvas;
    this.mmmap.initVector();
    this.mouseX;
    this.mouseY;
    this.newx;
    this.newY;
    this.oldX;
    this.oldY;
    this.mouseevent = '';
    this.logic = false;
    this.enableedit;
    this.pointImg = 'dot.GIF';
    this.midpointImg = 'Mdot.GIF';
    this.mode = mode;
    this.modeintext;
    if (typeof (this.mode) != 'undefined') {
        switch (this.mode) {
            case 0: this.modeintext = 'polygon'; break;
            case 1: this.modeintext = 'line'; break;
            case 2: this.modeintext = 'ellipse'; break;
        }
    }
    this.dragpoint = false;
    this.mouseoverdiv = false;
    this.dragMap = false;
    this.edit = 0;
    this.drag = false;
    this.delpoint = false;
    this.mouseX = 0;
    this.mouseY = 0;
    this.linepoint = [];
    this.lineseq = [];
    this.mDivArray = [];
    this.num = 0;
    this.lineID = '';
    this.lastlineID = '';
    this.previewlinetimeout = false;
    this.previewlineid = '';
    this.previewlineid1 = '';
    this.idlinearray = [];
    this.previewpointarray = [];
    this.numpreviewpoint = 0;
    this.distancediv = '';
    var oCursor;
    this.oCursor = oCursor;
    this.sumdistance = 0;
    this.sumdistancediv = '';
    this.mouseisoverdiv = false;
    this.previewdiv_array = [];
    this.templine = '';
    this.dblclick = false;
    this.drawlinetimeout = false;
    this.command = '';
    this.selectedcolor = '';
    this.saveURL = '';
    this.divwidth = "8px";
    this.divheight = "8px";
    this.divsize = "9px";
    this.fontsize = "1%";
    this.linecolor = '#4F4F4F';
    this.fillcolor = '#8BEF59';
    this.fillopacity = '0.6';
    this.lineopacity = '0.8';
    this.linewidth = 3;
    this.zIndex = 0;
    if (typeof (this.canvas) != 'undefined') {
        this.linecolor = this.canvas.canvas_line_color;
        this.fillcolor = this.canvas.canvas_fill_color;
        this.fillopacity = this.canvas.canvas_fill_opac;
        this.lineopacity = this.canvas.canvas_line_opac;
        this.linewidth = this.canvas.canvas_line_width;
    }
    this.hasline = false;
    this.lineObject = this;
    this.mmmap.setMoveMapWhenDBLClicked(false);
    this.user_defined_popup_content = "";
    this.user_defined_title = "";
    this.description_th = "";
    this.description_en = "";
    this.title_th = "";
    this.title_en = "";
    this.shortdescription_th = "";
    this.shortdescription_en = "";
    this.private = "";
    this.label = "";
    this.labeldiv = '';
    this.showeditpopup = false;
    this.addPoint = function addPoint(Lat, Long, isArraytoLine) {
        if (this.dblclick) {
            this.dblclick = false;
            return 0;
        }
        if (this.previewlineid) {
            this.mmmap.removeVector(this.mmmap.getMapDiv().lineObject.previewlineid);
        }
        if (this.num > 0) {
            if (this.linepoint[this.num - 1][0] == Long && this.linepoint[this.num - 1][1] == Lat) return 0;
        }
        if (this.lineObject.drag == false) {
            if (this.lineObject.dragMap == false) {
                var i = this.num;
                var Lat = Lat;
                var Long = Long;
                {
                    this.linepoint[i] = [Long, Lat, 0];
                }
                if (this.logic) {
                    var testdiv = document.createElement("div");
                    testdiv.style.cursor = "pointer";
                    testdiv.onmousedown = this.divMousedown;
                    testdiv.onmouseup = this.dragPoint;
                    testdiv.onmouseover = this.divMouseover;
                    testdiv.onmouseout = this.divMouseout;
                    testdiv.style.width = this.divsize;
                    testdiv.style.height = this.divsize;
                    testdiv.style.zIndex = "3000";
                    testdiv.style.fontSize = this.fontsize;
                    testdiv.style.border = "1px solid " + this.linecolor;
                    testdiv.style.backgroundColor = "#FFFFFF";
                    testdiv.lineObject = this;
                    testdiv.seq = this.num;
                    testdiv.latitude = Lat;
                    testdiv.longitude = Long;
                    var markerID = this.mmmap.drawCustomDiv(testdiv, Lat, Long, "");
                    testdiv.markerID = markerID;
                    var div = this.mmmap.getCustomDiv(markerID);
                    if (window.YAHOO) {
                        var dd1 = new YAHOO.util.DD(div);
                    }
                    if (this.num > 2 && this.mode == 0) {
                        this.lineseq[i] = markerID;
                        {
                            if (!isArraytoLine || typeof (isArraytoLine) == 'undefined') {
                                this.rebuildLine(Lat, Long, markerID);
                            }
                        }
                    }
                    else { this.lineseq[i] = markerID; }
                }
                if (this.num > 0) {
                    this.drawLine();
                }
                if (this.num >= 2 && this.mode == 0) {
                    this.drawLastLine();
                }
                if (this.num >= 2 && this.mode == 0 && this.logic) {
                    this.addMidPoint();
                }
                else if (this.mode == 1 && this.num > 0 && this.logic) {
                    this.addMidPoint();
                }
                if (this.distancediv != '') {
                    var dt = document.getElementById(this.distancediv);
                    var cursor = this.getPosition();
                    dt.style.left = cursor.x + 15 + "px";
                    dt.style.top = cursor.y + 10 + "px";
                }
                this.num++;
            }
        }
        else {
            this.drag = false;
        }
    };
    this.drawLine = function drawLine() {
        var lineObject = this.lineObject;
        var lineTitle = lineObject.user_defined_title != '' ? lineObject.user_defined_title : '';
        if (lineObject.lineID != '') {
            lineObject.templine = lineObject.lineID;
        }
        lineObject.lineID = lineObject.mmmap.drawPolyline(lineObject.linepoint, 1, 15, lineTitle, "", false, false, lineObject);
        if (lineObject.templine != '') { lineObject.mmmap.removeVector(lineObject.templine); }
    };
    this.drawLastLine = function drawLastLine() {
        this.linepoint[this.num + 1] = this.linepoint[0];
    };
    this.addMidPoint = function addMidPoint() {
        var z = this.num;
        var del = 0;
        var compare = 2;
        if (this.delpoint == true) { del = 1; this.dragpoint = false; }
        if (this.dragpoint == true) { z++; this.dragpoint = false; }
        {
            if (this.mode == 1) { z--; compare = 0; }
            {
                if (z > compare) {
                    for (var i = 0; i < z + del; i++) {
                        {
                            var tempdiv = this.mDivArray[i][4];
                            if (tempdiv) {
                                this.mmmap.removeCustomDivs(tempdiv);
                                this.mDivArray[i].pop();
                            }
                        }
                    }
                }
            }
        }
        for (var i = 1; i <= this.num - del; i++) {
            var latnew = (parseFloat(this.linepoint[i][1]) + parseFloat(this.linepoint[i - 1][1])) / 2;
            var longjnew = (parseFloat(this.linepoint[i][0]) + parseFloat(this.linepoint[i - 1][0])) / 2;
            var testdiv = document.createElement("div");
            testdiv.onmousedown = this.divMousedown;
            testdiv.onmouseup = this.dragMidPoint;
            testdiv.onmouseover = this.divMouseover;
            testdiv.onmouseout = this.divMouseout;
            testdiv.style.width = this.divsize;
            testdiv.style.height = this.divsize;
            testdiv.style.fontSize = this.fontsize;
            testdiv.style.zIndex = "3000";
            testdiv.style.cursor = "pointer";
            testdiv.style.border = "1px solid " + this.linecolor;
            testdiv.style.backgroundColor = "#FFFFFF";
            testdiv.style.opacity = '0.5';
            testdiv.style.filter = ' alpha(opacity=50)';
            testdiv.latitude = latnew;
            testdiv.longitude = longjnew;
            testdiv.lineObject = this;
            var markerID = this.mmmap.drawCustomDiv(testdiv, latnew, longjnew, "");
            testdiv.markerID = markerID;
            var div = this.mmmap.getCustomDiv(markerID);
            if (window.YAHOO) {
                var dd1 = new YAHOO.util.DD(div);
            }
            this.mDivArray[i - 1] = [longjnew, latnew, this.lineseq[i - 1], this.lineseq[i], markerID];
        }
        var i = this.num - del;
        if (this.mode == 0) {
            var latnew = (parseFloat(this.linepoint[0][1]) + parseFloat(this.linepoint[i][1])) / 2;
            var longjnew = (parseFloat(this.linepoint[0][0]) + parseFloat(this.linepoint[i][0])) / 2;
            var testdiv = document.createElement("div");
            testdiv.onmousedown = this.divMousedown;
            testdiv.onmouseup = this.dragMidPoint;
            testdiv.onmouseover = this.divMouseover;
            testdiv.onmouseout = this.divMouseout;
            testdiv.latitude = latnew;
            testdiv.longitude = longjnew;
            testdiv.lineObject = this;
            testdiv.style.width = this.divsize;
            testdiv.style.height = this.divsize;
            testdiv.style.fontSize = this.fontsize;
            testdiv.style.zIndex = "3000";
            testdiv.style.border = "1px solid " + this.linecolor;
            testdiv.style.backgroundColor = "#FFFFFF";
            testdiv.style.opacity = '0.5';
            testdiv.style.filter = ' alpha(opacity=50)';
            var markerID = this.mmmap.drawCustomDiv(testdiv, latnew, longjnew, "");
            testdiv.markerID = markerID;
            var div = this.mmmap.getCustomDiv(markerID);
            if (window.YAHOO) {
                var dd1 = new YAHOO.util.DD(div);
            }
            this.mDivArray[i] = [longjnew, latnew, this.lineseq[i], this.lineseq[0], markerID];
        }
    };
    this.rebuildLine = function rebuildLine(Lat, Long, markerID) {
        var distancelist = [];
        for (var i = 0; i < this.num; i++) {
            var diflat = Lat - this.mDivArray[i][1];
            var diflong = Long - this.mDivArray[i][0];
            var value = Math.sqrt(Math.pow(diflong, 2) + Math.pow(diflat, 2));
            distancelist[i] = [value, this.mDivArray[i][4]];
        }
        for (var i = 0; i < this.num - 1; i++) {
            for (var j = i + 1; j < this.num; j++) {
                if (distancelist[i][0] < distancelist[j][0]) {
                    var temp = distancelist[j];
                    distancelist[j] = distancelist[i];
                    distancelist[i] = temp;
                }
            }
        }
        mDivID = distancelist[this.num - 1][1];
        var mDiv = this.num;
        var tempMDiv = [];
        this.mmmap.removeCustomDivs(mDivID);
        this.mmmap.removeVector(this.lineID);
        var found = 0;
        var posL, posR, pos;
        var L, R;
        var seq;
        for (var i = 0; i < mDiv && found == 0; i++) {
            if (this.mDivArray[i][4] == mDivID) {
                R = this.mDivArray[i][3];
                L = this.mDivArray[i][2];
                for (var i = 0; i < this.num; i++) {
                    if (this.lineseq[i] == R) {
                        seq = i;
                        found = 1;
                    }
                }
                posL = this.linepoint[seq - 1];
                posR = this.linepoint[seq];
                found = 1;
                pos = i;
            }
        }
        var temp = [];
        var tempSeq = [];
        var j = 0;
        if (R != this.lineseq[0]) {
            if (R != this.lineseq[this.num]) {
                var found = 0;
                for (var i = seq; i < this.num; i++) {
                    temp[j] = this.linepoint[i];
                    tempSeq[j] = this.lineseq[i];
                    j++;
                }
                j = 0;
                this.linepoint[seq] = [Long, Lat, 0];
                for (var i = seq + 1; i <= this.num; i++) {
                    this.linepoint[i] = temp[j];
                    this.lineseq[i] = tempSeq[j];
                    j++;
                }
            }
        }
        else {
            this.linepoint[this.num] = [Long, Lat, 0];
        }
        if (R != this.lineseq[0]) {
            this.lineseq[seq] = markerID;
        }
        else {
            this.lineseq[this.num] = markerID;
        }
    };
    this.divMousedown = function divMousedown(e) {
        this.lineObject.mmmap.getMapDiv().lineObject = this.lineObject;
        if (!this.lineObject.logic) {
            document.pointdraging = true;
        }
        if (document.getElementById('point-popup')) {
            var popup = document.getElementById('point-popup');
            popup.parentNode.removeChild(popup);
        }
        if (document.getElementById('MM-dtdiv')) {
            document.getElementById('MM-dtdiv').style.visibility = "hidden";
        }
        this.lineObject.drag = true;
        var e = e || window.event;
        var cursor = { x: 0, y: 0 };
        if (e.pageX || e.pageY) {
            this.lineObject.mouseX = e.pageX;
            this.lineObject.mouseY = e.pageY;
        }
        else {
            var de = document.documentElement;
            var b = document.body;
            this.lineObject.mouseX = e.clientX + (de.scrollLeft || b.scrollLeft) - (de.clientLeft || 0);
            this.lineObject.mouseY = e.clientY + (de.scrollTop || b.scrollTop) - (de.clientTop || 0);
        }
    };
    this.divMouseover = function() {
        this.lineObject.mouseisoverdiv = true;
    };
    this.divMouseout = function() {
        this.lineObject.mouseisoverdiv = false;
        this.lineObject.editLineEnable(false);
    };
    this.checkmousedown = function checkmousedown(e) {
        document.pointdraging = false;
        e = e || window.event;
        var cursor = { x: 0, y: 0 };
        if (e.pageX || e.pageY) {
            this.mouseX = e.pageX;
            this.mouseY = e.pageY;
        }
        else {
            var de = document.documentElement;
            var b = document.body;
            this.mouseX = e.clientX + (de.scrollLeft || b.scrollLeft) - (de.clientLeft || 0);
            this.mouseY = e.clientY + (de.scrollTop || b.scrollTop) - (de.clientTop || 0);
        }
    };
    this.dragPoint = function dragPoint(e) {
        if (!this.lineObject.logic) {
            document.pointdraging = true;
        }
        this.lineObject.mouseisoverdiv = false;
        this.lineObject.drag = false;
        var e = e || window.event;
        var cursor = { x: 0, y: 0 };
        if (e.pageX || e.pageY) {
            cursor.x = e.pageX;
            cursor.y = e.pageY;
        }
        else {
            var de = document.documentElement;
            var b = document.body;
            cursor.x = e.clientX + (de.scrollLeft || b.scrollLeft) - (de.clientLeft || 0);
            cursor.y = e.clientY + (de.scrollTop || b.scrollTop) - (de.clientTop || 0);
        }
        var x = '';
        var y = '';
        if (e.pageX || e.pageY) {
            x = this.lineObject.mouseX;
            y = this.lineObject.mouseY;
        }
        else if (this.lineObject.logic == true) {
            x = this.lineObject.oldX;
            y = this.lineObject.oldY;
        }
        else {
            x = this.lineObject.mouseX;
            y = this.lineObject.mouseY;
        }
        if (cursor.x != x && cursor.y != y) {
            this.lineObject.hidePreviewDivs();
            this.lineObject.dropPoint(this);
            if (!this.lineObject.logic) this.lineObject.drawDistanceLabel();
        }
        else {
            if (!this.lineObject.logic) {
                noBubble(e);
                this.lineObject.pointPopup(e, this);
            }
            else {
                this.lineObject.setListenToEvents(false);
            }
        }
    };
    this.dropPoint = function dropPoint(div) {
        document.pointdraging = false;
        var lineObject = this;
        lineObject.drag = true;
        lineObject.dragpoint = true;
        var mLat;
        var mLong;
        var lat = this.mmmap.mouseCursorLat();
        var longj = this.mmmap.mouseCursorLong();
        var pointNum = div.markerID;
        var L, R, C, found = 0;
        if (lineObject.num < 1) { C = 0; }
        else {
            for (var i = 0; i < lineObject.num; i++) {
                if (lineObject.lineseq[i] == pointNum) {
                    C = i;
                }
            }
        }
        lineObject.mmmap.removeCustomDivs(div.markerID);
        lineObject.linepoint[C] = [longj, lat, 0];
        if (lineObject.mode == 0 && C == 0) {
            lineObject.linepoint[lineObject.num] = [longj, lat, 0];
        }
        lineObject.drag = true;
        var testdiv = document.createElement("div");
        testdiv.style.cursor = "pointer";
        testdiv.lineObject = lineObject;
        testdiv.onmousedown = lineObject.divMousedown;
        testdiv.onmouseover = lineObject.divMouseover;
        testdiv.onmouseout = lineObject.divMouseout;
        testdiv.onmouseup = lineObject.dragPoint;
        testdiv.style.width = this.divsize;
        testdiv.style.height = this.divsize;
        testdiv.style.fontSize = this.fontsize;
        testdiv.style.zIndex = "3000";
        testdiv.style.border = "1px solid " + this.linecolor;
        testdiv.style.backgroundColor = "#FFFFFF";
        testdiv.latitude = lineObject.mmmap.mouseCursorLat();
        testdiv.longitude = lineObject.mmmap.mouseCursorLong();
        testdiv.seq = pointNum;
        var markerID = lineObject.mmmap.drawCustomDiv(testdiv, lineObject.mmmap.mouseCursorLat(), lineObject.mmmap.mouseCursorLong(), "");
        testdiv.markerID = markerID;
        lineObject.lineseq[C] = markerID;
        var div = lineObject.mmmap.getCustomDiv(markerID);
        if (window.YAHOO) {
            var dd1 = new YAHOO.util.DD(div);
        }
        if (lineObject.num > 1) {
            lineObject.mmmap.removeVector(lineObject.lineID);
            lineObject.drawLine();
        }
        if (lineObject.mode == 1) {
            lineObject.num--;
            lineObject.addMidPoint();
            lineObject.num++;
        }
        if (lineObject.num > 2 && lineObject.mode == 0) {
            lineObject.num--;
            lineObject.drawLastLine();
            lineObject.addMidPoint();
            lineObject.num++;
        }
        lineObject.drag = false;
        lineObject.dragMap = false;
        if (document.getElementById('MM-dtdiv')) {
            document.getElementById('MM-dtdiv').style.visibility = "visible";
        }
    };
    this.dragMidPoint = function dragMidPoint(e) {
        if (!this.lineObject.logic) {
            document.pointdraging = true;
        }
        var e = e || window.event;
        var cursor = { x: 0, y: 0 };
        if (e.pageX || e.pageY) {
            cursor.x = e.pageX;
            cursor.y = e.pageY;
        }
        else {
            var de = document.documentElement;
            var b = document.body;
            cursor.x = e.clientX + (de.scrollLeft || b.scrollLeft) - (de.clientLeft || 0);
            cursor.y = e.clientY + (de.scrollTop || b.scrollTop) - (de.clientTop || 0);
        }
        if (cursor.x != this.mouseX && cursor.y != this.mouseY) {
            this.lineObject.dropMidPoint(this);
            if (!this.lineObject.logic) this.lineObject.drawDistanceLabel();
        }
    };
    this.dropMidPoint = function dropMidPoint(div) {
        document.pointdraging = false;
        var lat = this.mmmap.mouseCursorLat();
        var longj = this.mmmap.mouseCursorLong();
        var lineObject = this;
        var tempMDiv = [];
        this.mmmap.removeCustomDivs(div.markerID);
        lineObject.mmmap.removeVector(lineObject.lineID);
        var found = 0;
        var posL, posR, pos;
        var L, R;
        var seq;
        for (var i = 0; i < lineObject.num && found == 0; i++) {
            if (lineObject.mDivArray[i][4] == div.markerID) {
                R = lineObject.mDivArray[i][3];

                for (var i = 0; i < lineObject.num; i++) {
                    if (lineObject.lineseq[i] == R) {
                        seq = i;
                        found = 1;
                    }
                }
                posL = lineObject.linepoint[seq - 1];
                posR = lineObject.linepoint[seq];
                found = 1;
                pos = i;
            }
        }
        var temp = [];
        var tempSeq = [];
        var j = 0;
        if (R != 0) {
            if (R != lineObject.lineseq[lineObject.num]) {
                var found = 0;
                for (var i = seq; i < lineObject.num; i++) {
                    temp[j] = lineObject.linepoint[i];
                    tempSeq[j] = lineObject.lineseq[i];
                    j++;
                }
                j = 0;
                lineObject.linepoint[seq] = [longj, lat, 0];
                for (var i = seq + 1; i <= lineObject.num; i++) {
                    lineObject.linepoint[i] = temp[j];
                    lineObject.lineseq[i] = tempSeq[j];
                    j++;
                }
            }
        }
        else {
            lineObject.linepoint[lineObject.num] = [longj, lat, 0];
        }
        var testdiv = document.createElement("div");
        testdiv.style.cursor = "pointer";
        testdiv.onmousedown = lineObject.divMousedown;
        testdiv.onmouseout = lineObject.divMouseout;
        testdiv.onmouseover = lineObject.divMouseover;
        testdiv.onmouseup = lineObject.dragPoint;
        testdiv.lineObject = lineObject;
        testdiv.style.width = this.divsize;
        testdiv.style.height = this.divsize;
        testdiv.style.fontSize = this.fontsize;
        testdiv.style.zIndex = "3000";
        testdiv.style.border = "1px solid " + this.linecolor;
        testdiv.style.backgroundColor = "#FFFFFF";
        testdiv.seq = lineObject.num;
        testdiv.latitude = lineObject.mmmap.mouseCursorLat();
        testdiv.longitude = lineObject.mmmap.mouseCursorLong();
        var markerID = lineObject.mmmap.drawCustomDiv(testdiv, this.mmmap.mouseCursorLat(), this.mmmap.mouseCursorLong(), "");
        testdiv.markerID = markerID;
        var div = lineObject.mmmap.getCustomDiv(markerID);
        if (window.YAHOO) {
            var dd1 = new YAHOO.util.DD(div);
        }
        if (R != 0) {
            lineObject.lineseq[seq] = markerID;
        }
        else {
            lineObject.lineseq[lineObject.num] = markerID;
        }
        lineObject.drawLine();
        if (lineObject.mode == 0) {
            lineObject.drawLastLine();
        }
        lineObject.addMidPoint();
        lineObject.num++;
        lineObject.drag = false;
        lineObject.dragMap = false;
    };
    this.pointPopup = function pointPopup(e, pointdiv) {
        if (this.logic == true || this.drag == true) {
            return 0;
        }
        if (!this.dblclick) {
            var lineObject = pointdiv.lineObject;
            lineObject.mouseisoverdiv = true;
            var cursor = {
                x: 0,
                y: 0
            };
            var divID = this.markerID;
            if (e.pageX || e.pageY) {
                cursor.x = e.pageX;
                cursor.y = e.pageY;
            }
            else {
                var de = document.documentElement;
                var b = document.body;
                cursor.x = e.clientX + (de.scrollLeft || b.scrollLeft) - (de.clientLeft || 0);
                cursor.y = e.clientY + (de.scrollTop || b.scrollTop) - (de.clientTop || 0);
            }
            if (document.getElementById('point-popup')) {
                var popup = document.getElementById('point-popup');
                popup.parentNode.removeChild(popup);
            }
            var menustyle = 'margin:7px; font-family:loma,tahoma; font-size: 9pt;cursor:pointer;text-decoration: underline';
            var popup = document.createElement('div');
            popup.id = 'point-popup';
            popup.lineObject = lineObject;
            popup.point = pointdiv;
            popup.innerHTML = '<span id="remove" style="' + menustyle + '">Remove this point</span><br><span id="cancel" style="' + menustyle + '" >Cancel</span>';
            popup.style.position = "absolute";
            popup.style.left = cursor.x;
            popup.style.width = '120px';
            popup.style.top = cursor.y;
            popup.style.backgroundColor = "#EFEFEF";
            popup.style.border = '1px solid #9F9F9F';
            popup.style.zIndex = '10000';
            document.body.appendChild(popup);
            document.getElementById('cancel').onmousedown = lineObject.delPopup;
            document.getElementById('remove').onmousedown = lineObject.delPoint;
            lineObject.mmmap.getMapDiv().onmousedown = function() { lineObject.delPopup(); };
        }
        else {
            this.dblclick = false;
        }
    };
    this.endPopup = function endPopup() {
        if (this.mmmap.getMapDiv().lineObject.previewlineid) {
            this.mmmap.removeVector(mmmap.getMapDiv().lineObject.previewlineid);
        }
        var popup = document.getElementById('point-popup');
        popup.parentNode.removeChild(popup);
        this.mmmap.getMapDiv().onmouseup = mmmap.getMapDiv().lineObject.checkDragMap;
        this.mmmap.getMapDiv().lineObject.drag = false;
        this.mmmap.getMapDiv().lineObject.dragMap = false;
    };
    this.delPopup = function delPopup() {
        document.pointdraging = false;
        var popup = document.getElementById('point-popup');
        var lineObject = popup.lineObject;
        popup.parentNode.removeChild(popup);
        lineObject.mmmap.getMapDiv().onmouseup = lineObject.checkDragMap;
        lineObject.mmmap.getMapDiv().onmousedown = lineObject.checkmousedown;
        lineObject.mouseisoverdiv = false;
    };
    this.delPoint = function() {
        var lineObject = this.parentNode.lineObject;
        var point = this.parentNode.point;
        var divID = point.markerID;
        var found = false;
        for (var i = 0; i < lineObject.lineseq.length && found == false; i++) {
            if (divID == lineObject.lineseq[i]) {
                lineObject.lineseq[i] = '';
                lineObject.linepoint[i] = '';
                found = true;
            }
        }
        var lineseaq_temp = new Array();
        var linepoint_temp = new Array();
        for (var i = 0; i < lineObject.lineseq.length; i++) {
            if (lineObject.lineseq[i] != '') {
                lineseaq_temp.push(lineObject.lineseq[i]);
                linepoint_temp.push(lineObject.linepoint[i]);
            }
        }
        lineObject.lineseq = lineseaq_temp;
        lineObject.linepoint = linepoint_temp;
        lineObject.num--;
        lineObject.rePaintLine();
        if (!lineObject.logic)
            lineObject.drawDistanceLabel();
        lineObject.delPopup();
    };
    this.rePaintLine = function rePaintLine() {
        if (this.mode == 0 && this.num <= 2) {
            this.mode = 1;
        }
        if (this.mode == 0) {
            this.num--;
            this.drawLastLine();
            this.num++;
        }
        this.drawLine();
        this.num--;
        this.addMidPoint();
        this.num++;
        this.editLineEnable(false);
    };
    this.getLineArray = function getLineArray() {
        if (this.mode == 0) this.lineObject.linepoint.pop();
        return this.lineObject.linepoint;
    };
    this.getJSON = function getJSON() {
        var myJSONObject = '{"mode":"' + this.getLineMode() + '", "fillcolor":"' + this.getFillColor() + '", "linecolor":"' + this.getLineColor() + '", "fillopacity":"' + this.getFillOpacity() + '", "lineopacity":"' + this.getLineOpacity() + '", "title":"' + this.getTitle() + '", "detail":"' + this.getDescription() + '", "points":[';
        for (var i = 0; i < this.num - 1; i++) {
            myJSONObject += '{"lat": "' + this.linepoint[i][1] + '", "lon": "' + this.linepoint[i][0] + '"},';
        }
        var i = this.num - 1;
        myJSONObject += '{"lat": "' + this.linepoint[i][1] + '", "lon": "' + this.linepoint[i][0] + '"}]}';
        return eval('(' + myJSONObject + ')');
    };
    this.getJSONText = function getJSON() {
        var myJSONObject = '{"mode":"' + this.getLineMode()
    + '", "id":"' + this.getID()
    + '", "fillcolor":"' + this.getFillColor()
    + '", "linecolor":"' + this.getLineColor()
    + '", "fillopacity":"' + this.getFillOpacity()
    + '", "lineopacity":"' + this.getLineOpacity()
    + '", "linewidth":"' + this.getLineWidth()
    + '", "zIndex":"' + this.zIndex
    + '", "title":"' + this.getTitle()
    + '", "detail":"' + this.getDescription()
    + '", "title_th":"' + this.getTitleTh()
    + '", "title_en":"' + this.getTitleEn()
    + '", "description_th":"' + this.getDescriptionTh()
    + '", "description_en":"' + this.getDescriptionEn()
    + '", "private":"' + this.getPrivate()
    + '", "points":[';
        for (var i = 0; i < this.num - 1; i++) {
            myJSONObject += '{"lat": "' + this.linepoint[i][1] + '", "lon": "' + this.linepoint[i][0] + '"},';
        }
        var i = this.num - 1;
        myJSONObject += '{"lat": "' + this.linepoint[i][1] + '", "lon": "' + this.linepoint[i][0] + '"}]}';
        return myJSONObject;
    };
    this.setListenToEvents = function setListenToEvents(_logic, isArrayToLine) {
        this.logic = _logic;
        var logic = this.logic;
        if (this.logic == true) {
            var temp = this.linepoint;
            this.linepoint = [];
            this.num = 0;
            this.removeVector();
            for (var i = 0; i < temp.length; i++) {
                this.addPoint(temp[i][1], temp[i][0]);
            }
            this.edit = 1;
            this.onmouseup = this.lineObject.checkDragMap;
            if (this.num > 0) {
                if (this.mode == 0) {
                    for (var i = 0; i < this.num; i++) {
                        this.mmmap.showCustomDivs(this.lineseq);
                        if (this.num > 2) {
                            this.mmmap.showCustomDivs(this.lineseq);
                        }
                    }
                }
                else if (this.mode == 1) {
                    for (var i = 0; i < this.num; i++) {
                        this.mmmap.showCustomDivs(this.lineseq);
                        if (i < this.num - 1) {
                            this.mmmap.showCustomDivs(this.lineseq);
                        }
                    }
                }
            }
            if (this.mode == 1) {
                this.initPreviewDivs();
                this.mmmap.getMapDiv().lineObject = this;
                document.lineObject = this.lineObject;
                document.onmousemove = this.lineObject.mouseMoving;
            }
            else if (this.mode == 0) {
                try {
                    var distancediv = document.createElement("div");
                    var lat = this.mmmap.mouseCursorLat();
                    var lon = this.mmmap.mouseCursorLong();
                    distancediv.lat = lat;
                    distancediv.style.position = "absolute";
                    distancediv.lon = lon;
                    distancediv.style.width = "120px";
                    distancediv.style.border = "";
                    distancediv.style.backgroundColor = "#E6F7B3";
                    distancediv.style.zIndex = "300000";
                    distancediv.style.fontSize = "11px";
                    var dtid = this.mmmap.drawCustomDiv(distancediv, lat, lon, "");
                    distancediv.id = dtid;
                    this.distancediv = dtid;
                    this.mmmap.hideCustomDiv(this.distancediv);
                    document.lineObject = this;
                    document.onmousemove = this.lineObject.polygonMouseMoving;
                }
                catch (e) { }
            }
            this.setLineMode(this.mode);
            this.mmmap.setMoveMapWhenDBLClicked(false);
        }
        else if (logic == false) {
            document.MMCanvas.drawing = false;
            this.mmmap.setMoveMapWhenDBLClicked(this.defaultMoveMapWhenDBLClicked);
            this.edit = false;
            this.mmmap.hideCustomDiv(this.distancediv);
            this.mmmap.getMapDiv().onmousemove = '';
            document.onmousemove = '';
            this.mouseevent = this.mmmap.getMapDiv().getAttribute('onmouseup');
            this.mmmap.getMapDiv().setAttribute('onmouseup', '');
            if (this.num > 1) this.hasline = true;
            if (this.rulerButtonFn && !isArrayToLine) {
                this.rulerButtonFn();
            }
            if (this.mode == 0) {
                this.editLineEnable(false);
                this.drawDistanceLabel();
                for (var i = 0; i < this.num; i++) {
                    this.mmmap.hideCustomDiv(this.lineseq);
                    if (this.num > 2) {
                        this.mmmap.hideCustomDiv(this.lineseq);
                    }
                }
            }
            else if (this.mode == 1) {
                this.drawDistanceLabel();
                this.editLineEnable(false);
                for (var i = 0; i < this.num; i++) {
                    this.mmmap.hideCustomDiv(this.lineseq);
                    if (i < this.num - 1) {
                        this.mmmap.hideCustomDiv(this.lineseq);
                    }
                }
            }
            if (this.num > 0) {
                this.drawLine();
            }
            if (typeof (this.enableedit) == 'undefined') this.enableedit = true;
        }
        return this.hasline;
    };
    this.setPointImg = function setPointImg(img1, img2) {
        this.pointImg = img1;
        this.midpointImg = img2;
    };
    this.setID = function(id) {
        this.id = id;
    };
    this.getID = function() {
        return this.id;
    };
    this.save = function save() {
        if (document.getElementById('shape-title-th')) this.setTitleTh(document.getElementById('shape-title-th').value);
        if (document.getElementById('shape-title-en')) this.setTitleEn(document.getElementById('shape-title-en').value);
        if (document.getElementById('shape-desc')) mylang == "en" ? this.setDescriptionEn(document.getElementById('shape-desc').value) : this.setDescriptionTh(document.getElementById('shape-desc').value);

        /*var linearray = this.getLineArray();
        parameters = '';
        for(var i=0;i<linearray.length;i++) {
        if(parameters!='') parameters+= '&';
        parameters += 'lat[]='+linearray[i][1]+'&lon[]='+linearray[i][0];   
        }*/
        var linemode = this.getLineMode();
        /*if(this.getID()) {
        parameters += '&sid='+this.getID();
        }*/
        parameters = 'text=' + encodeURIComponent(this.getJSONText());
        document.currentShape = this;
        callback = function(txt) {
            var data = "";
            if (txt.length > 1) {
                data = eval(txt);
                //document.currentShape.setID(data[0].sid);
                //document.MMCanvas.loadShape();
            }
        };
        new this.ajax(this.saveURL, parameters, callback, this);
    };
    this.setSaveURL = function(url) {
        this.saveURL = url;
    };
    this.deleteShape = function() {
        parameters = 'sid=' + this.getID();
        new this.ajax('shape/del', parameters, callback = false, this);
    };
    this.checkDragMap = function checkDragMap(e) {
        var lineObject = (this.lineObject) ? this.lineObject : document.lineObject;
        var e = e || window.event;
        var cursor = { x: 0, y: 0 };
        if (e.pageX || e.pageY) {
            cursor.x = e.clientX;
            cursor.y = e.clientY;
        }
        else {
            var de = document.documentElement;
            var b = document.body;
            cursor.x = e.clientX + (de.scrollLeft || b.scrollLeft) - (de.clientLeft || 0);
            cursor.y = e.clientY + (de.scrollTop || b.scrollTop) - (de.clientTop || 0);
        }
        if (cursor.x != this.mouseX && cursor.y != this.mouseY) {
            lineObject.dragMap = true;
        }
        else {
            lineObject.dragMap = false;
        }
        if (cursor.x == this.oldX && cursor.y == this.oldY) {
            lineObject.logic = false;
            return false;
        }
        else {
            if (lineObject.logic != false) {
                lineObject.addPoint(lineObject.mmmap.mouseCursorLat(), lineObject.mmmap.mouseCursorLong());
            }
        }
        lineObject.oldX = cursor.x;
        lineObject.oldY = cursor.y;
    };
    this.setLineMode = function setLineMode(mode) {
    };
    this.clearLine = function clearLine() {
        try { /* to be fix*/
            var lineObject = this;
            if (lineObject.num > 0) {
                if (this.mode == 0) {
                    for (var i = 0; i < lineObject.num; i++) {
                        lineObject.mmmap.removeCustomDivs(lineObject.lineseq[i]);
                        lineObject.mmmap.removeCustomDivs(lineObject.mDivArray[i][4]);
                    }
                }
                else if (this.mode == 1) {
                    for (var i = 0; i < lineObject.num; i++) {
                        this.mmmap.removeCustomDivs(lineObject.lineseq[i]);
                        if (i < lineObject.num - 1) {
                            lineObject.mmmap.removeCustomDivs(lineObject.mDivArray[i][4]);
                        }
                    }
                }
                if (lineObject.lineID != '') lineObject.mmmap.removeVector(lineObject.lineID);
                lineObject.linepoint = [];
                lineObject.num = 0;
            }
            //alert('remove: '+lineObject.lineID);
            if (lineObject.lineID != '') {
                //alert(lineObject.lineID+'<-remove: '+mmmap.vectortype);
                for (var i = 0; i < mmmap.mapvector.length; i++) {
                    //alert(i+': '+mmmap.mapvector[i].id);
                }
                lineObject.mmmap.removeVector(lineObject.lineID);
            }
            if (lineObject.sumdistancediv != '') {
                lineObject.mmmap.removeCustomDivs(lineObject.sumdistancediv);
            }
            if (this.canvas) {
                /*var temp = new Array();
                for(var i=0;i<this.canvas.shapes.length;i++) {
                if(typeof(this.canvas.shapes[i])!='undefined') {
                temp.push(this.canvas.shapes[i]);
                }
                }
                this.canvas.shapes = temp;
                this.canvas.numshapes = temp.length + 1;
                alert(this.canvas);*/
                this.canvas.deleteShape(this.id);
            }
        } catch (e) {
        }
    };
    this.getLineMode = function getLineMode() {
        return this.mode;
    };
    this.arrayToLine = function arrayToLine(linearray, mode) {
        this.num = 0;
        this.edit = false;
        this.mode = mode;
        this.point = linearray;
        for (var i = 0; i < linearray.length; i++) {
            this.addPoint(this.point[i][0], this.point[i][1]);
        }
        this.setListenToEvents(false);
    };
    this.setPoints = function(linearray) {
        if (typeof (this.mode) == 'undefined') {
            alert('Line mode missing.\n"line" or "polygon"');
            return false;
        }
        this.num = 0;
        this.edit = false;
        if (this.mode != 3) {
            this.clearLine();
            this.point = linearray;
            for (var i = 0; i < linearray.length; i++) {
                if (typeof (this.point[i]) != 'undefined') this.addPoint(this.point[i][0], this.point[i][1], isArrayToLine = true);
            }
        }
        else {
            //this.remove();
            if (typeof (this.getHeight()) == 'undefined' && typeof (this.getWidth()) != 'undefined') this.setHeight(this.getWidth());
            var attributes = {
                'title': this.getTitle(),
                'detailpopup': this.user_defined_popup_content,
                'width': this.getWidth(),
                'height': this.getHeight(),
                'linewidth': this.linewidth,
                'linecolor': this.linecolor,
                'lineopacity': this.lineopacity,
                'fillcolor': this.fillcolor,
                'fillopacity': this.fillopacity
            };
            if (this.mmmap.mapvector[this.lineID]) {
                this.mmmap.mapvector[this.lineID].lat = linearray[0];
                this.mmmap.mapvector[this.lineID].lon = linearray[1];
                this.rePaint();
            }
            else if (!this.mmmap.mapvector[this.lineID]) {
                this.setCenter(linearray[0], linearray[1]);
                this.lineID = this.mmmap.drawEllipse(linearray[0], linearray[1], 1, 15, attributes, this);
            }
        }
        if (this.label != "") {
            this.drawLabel();
        }
    };
    this.setPointsLongLat = function(linearray) {
        if (typeof (this.mode) == 'undefined') {
            alert('Line mode missing.\n"line" or "polygon"');
            return false;
        }
        this.num = 0;
        this.edit = false;
        this.point = linearray;
        for (var i = 0; i < linearray.length; i++) {
            this.addPoint(this.point[i][1], this.point[i][0], isArrayToLine = true);
        }
        if (this.label != "") {
            this.drawLabel();
        }
    };
    this.arrayToLine2 = function arrayToLine2(linearray, mode) {
        this.num = 0;
        this.mode = mode;
        this.linepoint = linearray;
        for (var i = 0; i < linearray.length; i++) {
            this.addPoint(this.linepoint[i][1], this.linepoint[i][0]);
        }
        this.setListenToEvents(false);
    };
    this.mouseMoving = function mouseMoving(event) {
        var lat = this.lineObject.mmmap.mouseCursorLat();
        var lon = this.lineObject.mmmap.mouseCursorLong();
        var resolution = Math.pow(2, this.lineObject.mmmap.getZoom());
        if (this.lineObject.num > 0 && this.lineObject.logic == true && this.lineObject.distancediv == '') {
            var distancediv = document.createElement("div");
            distancediv.lat = lat;
            distancediv.style.position = "absolute";
            distancediv.lon = lon;
            distancediv.style.width = "120px";
            distancediv.style.border = "";
            distancediv.style.backgroundColor = "#E6F7B3";
            distancediv.style.zIndex = "300000";
            distancediv.style.fontSize = "11px";
            var dtid = this.lineObject.mmmap.drawCustomDiv(distancediv, lat, lon, "");
            distancediv.id = dtid;
            this.lineObject.distancediv = dtid;
        }
        if (this.lineObject.distancediv != '') {
            var dt = document.getElementById(this.lineObject.distancediv);
            var cursor = this.lineObject.getPosition(event);
            dt.style.left = cursor.x + 15 + "px";
            dt.style.top = cursor.y + 10 + "px";
            dt.style.position = "absolute";
            dt.style.zIndex = "1000";
            dt.style.visibility = "visible";
            var distance = 0;
            distance = this.lineObject.lineDistance();
            distance = distance + this.lineObject.calcDistance(this.lineObject.linepoint[this.lineObject.num - 1][1], this.lineObject.linepoint[this.lineObject.num - 1][0], this.lineObject.mmmap.mouseCursorLat(), this.lineObject.mmmap.mouseCursorLong());
            distance = distance + '';
            distance = this.lineObject.addCommas(distance);
            var unit = (mylang == "en" ? " km" : " กม.");
            distance = distance.substr(0, distance.indexOf(".") + 3) + unit;
            dt.innerHTML = "<b>" + distance + "<br>Double Click to end</b>";
            this.lineObject.hidePreviewDivs();
            var lastdiv = this.lineObject.mmmap.getCustomDiv(this.lineObject.lineseq[this.lineObject.num - 1]);
            var lleft = parseInt(lastdiv.style.left);
            var ltop = parseInt(lastdiv.style.top);
            var xleft = longToPoint(lon, resolution);
            var xtop = latToPoint(lat, resolution);
            var x = Math.abs(lleft - xleft);
            var y = Math.abs(ltop - xtop);
            var c = (Math.pow(x, 2) + Math.pow(y, 2));
            var sqrtc = Math.sqrt(c);
            var numdiv = Math.round(sqrtc / 30);
            var xlat = Math.abs((this.lineObject.linepoint[this.lineObject.num - 1][1] - lat) / numdiv);
            var xlon = Math.abs((this.lineObject.linepoint[this.lineObject.num - 1][0] - lon) / numdiv);
            try {
                for (var i = 0; i < numdiv; i++) {
                    var pdiv = this.lineObject.mmmap.getCustomDiv(this.lineObject.previewpointarray[i]);
                    var calclat = (lat < this.lineObject.linepoint[this.lineObject.num - 1][1]) ? lat + xlat * (i) : lat - xlat * (i);
                    var calclong = (lon < this.lineObject.linepoint[this.lineObject.num - 1][0]) ? lon + xlon * (i) : lon - xlon * (i);
                    pdiv.style.position = "absolute";
                    pdiv.style.zIndex = "1000";
                    pdiv.style.top = latToPoint(calclat, resolution) - 2.5;
                    pdiv.style.left = longToPoint(calclong, resolution) - 2.5;
                    pdiv.style.visibility = "visible";
                    pdiv.style.width = '5px';
                    pdiv.style.height = '5px';
                }
            }
            catch (e) { }
        }
    };
    this.polygonMouseMoving = function(event) {
        if (this.lineObject.num >= 0) {
            var lat = this.lineObject.mmmap.mouseCursorLat();
            var lon = this.lineObject.mmmap.mouseCursorLong();
            var resolution = Math.pow(2, this.lineObject.mmmap.getZoom());
            var dt = document.getElementById(this.lineObject.distancediv);
            var cursor = this.lineObject.getPosition(event);
            dt.style.left = cursor.x + 15 + "px";
            dt.style.top = cursor.y + 10 + "px";
            dt.style.position = "absolute";
            dt.style.zIndex = "1000";
            dt.style.visibility = "visible";
            if (this.lineObject.num > 2) {
                dt.innerHTML = "<b>Double Click to end</b>";
            }
            else {
                dt.innerHTML = "<b>Mark at least 3 points to create a polygon</b>";
            }
        }
    };
    this.getPosition = function getPosition(event) {
        var cursor = { x: 0, y: 0 };
        cursor.x = myX - findPosX(mymap);
        cursor.y = myY - findPosY(mymap);
        return cursor;
    };
    this.calcDistance = function calcDistance(lat1, lon1, lat2, lon2) {
        var PI = 3.14159265359;
        var TWOPI = 6.28318530718;
        var DE2RA = 0.01745329252;
        var RA2DE = 57.2957795129;
        var ERAD = 6378.135;
        var ERADM = 6378135.0;
        var AVG_ERAD = 6371.0;
        var EPS = 0.000000000005;
        var KM2MI = 0.621371;
        var FLATTENING = 0;
        var distance = 0.0;
        var faz = 0.0;
        var baz = 0.0;
        var r = 1.0 - FLATTENING;
        var tu1 = 0.0;
        var tu2 = 0.0;
        var cu1 = 0.0;
        var su1 = 0.0;
        var cu2 = 0.0;
        var x = 0.0;
        var sx = 0.0;
        var cx = 0.0;
        var sy = 0.0;
        var cy = 0.0;
        var y = 0.0;
        var sa = 0.0;
        var c2a = 0.0;
        var cz = 0.0;
        var e = 0.0;
        var c = 0.0;
        var d = 0.0;
        var cosy1 = 0.0;
        var cosy2 = 0.0;
        if ((lon1 == lon2) && (lat1 == lat2))
            return distance;
        lon1 *= DE2RA;
        lon2 *= DE2RA;
        lat1 *= DE2RA;
        lat2 *= DE2RA;
        cosy1 = Math.cos(lat1);
        cosy2 = Math.cos(lat2);
        if (cosy1 == 0.0) cosy1 = 0.0000000001;
        if (cosy2 == 0.0) cosy2 = 0.0000000001;
        tu1 = r * Math.sin(lat1) / cosy1;
        tu2 = r * Math.sin(lat2) / cosy2;
        cu1 = 1.0 / Math.sqrt(tu1 * tu1 + 1.0);
        su1 = cu1 * tu1;
        cu2 = 1.0 / Math.sqrt(tu2 * tu2 + 1.0);
        x = lon2 - lon1;
        distance = cu1 * cu2;
        baz = distance * tu2;
        faz = baz * tu1;
        while (Math.abs(d - x) > EPS) {
            sx = Math.sin(x);
            cx = Math.cos(x);
            tu1 = cu2 * sx;
            tu2 = baz - su1 * cu2 * cx;
            sy = Math.sqrt(tu1 * tu1 + tu2 * tu2);
            cy = distance * cx + faz;
            y = Math.atan2(sy, cy);
            sa = distance * sx / sy;
            c2a = -sa * sa + 1.0;
            cz = faz + faz;
            if (c2a > 0.0) cz = -cz / c2a + cy;
            e = cz * cz * 2.0 - 1.0;
            c = ((-3.0 * c2a + 4.0) * FLATTENING + 4.0) * c2a * FLATTENING / 16.0;
            d = x;
            x = ((e * cy * c + cz) * sy * c + y) * sa;
            x = (1.0 - c) * x * FLATTENING + lon2 - lon1;
        }
        x = Math.sqrt((1.0 / r / r - 1.0) * c2a + 1.0) + 1.0;
        x = (x - 2.0) / x;
        c = 1.0 - x;
        c = (x * x / 4.0 + 1.0) / c;
        d = (0.375 * x * x - 1.0) * x;
        x = e * cy;
        distance = 1.0 - e - e;
        distance = ((((sy * sy * 4.0 - 3.0) * distance * cz * d / 6.0 - x) * d / 4.0 + cz) * sy * d + y) * c * ERAD * r;
        return (distance);
    };
    this.editLineEnable = function(bool) {
        if (this.mode == 0 && this.num <= 2 && this.edit == 0) {
            this.mode = 1;
            this.num--;
            this.addMidPoint();
            this.num++;
            this.drawDistanceLabel();
        }
        if (this.mouseisoverdiv || this.logic || this.drag || this.lineObject.logic) {
            return 0;
        }
        if (bool == true) {
            this.mmmap.hideCustomDiv(this.sumdistancediv);
            /*this.mmmap.getMapDiv().onmouseup = this.lineObject.checkDragMap;*/
            if (this.num > 0) {
                {
                    for (var i = 0; i < this.num; i++) {
                        this.mmmap.showCustomDiv(this.lineseq[i]);
                        if (i < this.num - 1 && this.mode == 1) {
                            this.mmmap.showCustomDiv(this.mDivArray[i][4]);
                        }
                        else if (this.mode == 0) {
                            this.mmmap.showCustomDiv(this.mDivArray[i][4]);
                        }
                    }
                }
            }
            if (this.mode == 1) {
            }
            this.setLineMode(this.mode);
            this.mmmap.setMoveMapWhenDBLClicked(false);
        }
        else if (bool == false) {
            this.mmmap.showCustomDiv(this.sumdistancediv);
            if (this.lineObject.mouseisoverdiv) {
                this.lineObject.mouseisoverdiv = false;
                return 0;
            }
            this.mmmap.getMapDiv().onmousemove = '';
            this.mouseevent = this.mmmap.getMapDiv().getAttribute('onmouseup');
            /*this.mmmap.getMapDiv().setAttribute('onmouseup','');*/
            for (var i = 0; i < this.previewpointarray.length; i++) {
                this.mmmap.removeCustomDivs(this.previewpointarray[i]);
            }
            this.previewpointarray = [];
            for (var i = 0; i < this.num && this.mDivArray.length; i++) {
                this.mmmap.hideCustomDiv(this.lineseq[i]);
                if (i < this.num - 1 && this.mode == 1) {
                    this.mmmap.hideCustomDiv(this.mDivArray[i][4]);
                }
                else if (this.mode == 0) {
                    this.mmmap.hideCustomDiv(this.mDivArray[i][4]);
                }
            }
        }
        setTimeout("this.mmmap.setMoveMapWhenDBLClicked(true)", 500);
    };
    this.drawDistanceLabel = function() {
        if (this.num <= 1) {
            try {
                this.mmmap.removeCustomDivs(this.lineseq[0]);
            } catch (e) { }
            if (this.sumdistancediv != '') {
                this.mmmap.removeCustomDivs(this.sumdistancediv);
            }
            return false;
        }
        var resolution = Math.pow(2, this.mmmap.getZoom());
        var lat = (this.linepoint[this.num - 1][1] + this.mDivArray[this.num - 2][1]) / 2;
        var lon = (this.linepoint[this.num - 1][0] + this.mDivArray[this.num - 2][0]) / 2;
        if (this.sumdistancediv != '') {
            this.mmmap.removeCustomDivs(this.sumdistancediv);
        }
        var distance = 0;
        if (this.mode == 1) {
            distance = this.lineDistance() + '';
            this.addCommas(distance);
            var unit = (mylang == "en") ? ' km' : " กม.";
            distance = 'ประมาณ ' + distance.substr(0, distance.indexOf(".") + 3) + unit;
        }
        else if (this.mode == 0) {
            distance = this.getArea(showunit = true);
            var rai = (this.getAreaRai(false) < 10000) ? '<br>' + this.getAreaRai('short') : '';
            distance += rai;
        }
        var sumdiv = document.createElement("div");
        sumdiv.latitude = lat;
        sumdiv.longitude = lon;
        sumdiv.innerHTML = '<b>' + distance + '</b>';
        sumdiv.style.border = "1px solid rgb(102, 102, 102)";
        sumdiv.style.backgroundColor = "rgb(255, 255, 153)";
        sumdiv.style.fontSize = "8pt";
        sumdiv.style.fontFamily = 'Tahoma';
        sumdiv.style.lineHeight = 'normal';
        sumdiv.style.zIndex = '3005';
        sumdiv.style.whiteSpace = 'nowrap';
        sumdiv.nowrap = "true";
        this.sumdistancediv = this.mmmap.drawCustomDiv(sumdiv, lat, lon, "");
    };
    this.lineDistance = function() {
        var distance = 0;
        for (var i = 0; i < this.num - 1; i++) {
            distance = distance + this.calcDistance(this.linepoint[i][1], this.linepoint[i][0], this.linepoint[i + 1][1], this.linepoint[i + 1][0]);
        }
        this.sumdistance = distance;
        return (distance);
    };
    this.getDistance = function(format) {
        if (this.mode != 1) return 0;
        var distance = this.sumdistance;
        if (typeof (format) == 'undefined') format = true;
        if (format) {
            distance = this.addCommas(distance)
            var unit = (mylang == "en") ? ' km' : " กม.";
            distance = distance.substr(0, distance.indexOf(".") + 3) + unit;
        }
        return distance;
    };
    this.addCommas = function addCommas(nStr) {
        nStr += '';
        var x = nStr.split('.');
        x1 = x[0];
        x2 = x.length > 1 ? '.' + x[1] : '';
        var rgx = /(\d+)(\d{3})/;
        while (rgx.test(x1)) {
            x1 = x1.replace(rgx, '$1' + ',' + '$2');
        }
        return x1 + x2;
    };
    this.hidePreviewDivs = function() {
        for (var i = 0; i < this.previewpointarray.length; i++) {
            try {
                var pdiv = this.mmmap.getCustomDiv(this.previewpointarray[i]);
                pdiv.style.visibility = "hidden";
            }
            catch (e) {
            }
        }
    };
    this.initPreviewDivs = function() {
        for (var i = 0; i < 50; i++) {
            var pdiv = document.createElement("div");
            pdiv.innerHTML = "";
            var calclat = 0;
            var calclong = 0;
            pdiv.lat = calclat;
            pdiv.lon = calclong;
            pdiv.style.position = "absolute";
            pdiv.style.backgroundColor = this.linecolor;
            pdiv.style.fontSize = "1%";
            pdiv.style.width = "5px";
            pdiv.style.height = "5px";
            pdiv.style.zIndex = "-300000";
            pdiv.style.top = latToPoint(calclat, resolution);
            pdiv.style.left = longToPoint(calclong, resolution);
            var pid = this.mmmap.drawCustomDiv(pdiv, calclat, calclong);
            pdiv.id = pid;
            this.mmmap.hideCustomDiv(mmmap.getCustomDiv(pid));
            this.previewpointarray[i] = pid;
            this.numpreviewpoint++;
        }
    };
    this.setRulerButtonFn = function(fn) {
        this.rulerButtonFn = fn;
    };
    this.editPopup = function(_lat, _lon) {
        var lat = _lat;
        var longt = _lon;
        if (typeof (_lat) == 'undefined' || typeof (_lon) == 'undefined') {
            lat = this.mmmap.mouseCursorLat();
            longt = this.mmmap.mouseCursorLong();
        }
        var onfocusevent = 'document.onkeydown=\'return true\'; document.onkeypress=\'return true\';';
        var onblurevent = 'mmmap.setKeyFocusAtMaparea();';
        var onclickevent = 'this.focus(); noBubble(event);';
        var makedragable = 'onmousemove="noBubble(event);" onmousedown="noBubble(event);"';
        var description = mylang == "en" ? this.getDescriptionEn() : this.getDescriptionTh();
        var name_th = mylang == "en" ? "Thai name" : "ชื่อภาษาไทย";
        var name_en = mylang == "en" ? "English name" : "ชื่อภาษาอังกฤษ";
        var desc = mylang == "en" ? "Description" : "รายละเอียด";
        var shapeType = mylang == "en" ? "Shape type" : "ประเภท";
        var shapeType_private = mylang == "en" ? "Private (Show in <a href=/user>my page</a>)" : "ส่วนตัว (แสดงใน <a href=/user>my page</a>)";
        var shapeType_public = mylang == "en" ? "Public" : "สาธารณะ";
        if (this.getPrivate() == "") this.setPrivate("N");
        var detail = '<script>'
    + '</script>'
    + '<div id="edit-shape-color" style="display:block; z-index:9000; font-size:11px;" onclick="this.focus();">'
    + name_th + ':<br/><input id="shape-title-th" type="text" value="' + this.getTitleTh() + '" style="width:100%; margin-bottom:5px;" onfocus="' + onfocusevent + '" onblur="' + onblurevent + '" onclick="' + onclickevent + '" ' + makedragable + '><br/>'
    + name_en + ':<br/><input id="shape-title-en" type="text" value="' + this.getTitleEn() + '" style="width:100%; margin-bottom:5px;" onfocus="' + onfocusevent + '" onblur="' + onblurevent + '" onclick="' + onclickevent + '" ' + makedragable + '><br/>'
    + desc + ':<br/><textarea id="shape-desc" style="width:100%; margin-bottom:5px; height:42px; _height:40px;" onfocus="' + onfocusevent + '" onblur="' + onblurevent + '" onclick="' + onclickevent + '" ' + makedragable + '>' + description + '</textarea><br/>'
    + shapeType + ':'
    + '  <input type="radio" id="shape-private-n" name="shape-private" value="N" onfocus="' + onfocusevent + '" onblur="' + onblurevent + '" onclick="' + onclickevent + ' document.selectedShape.lineobject.setPrivate(this.value);" ' + makedragable + '>' + shapeType_public
    + '  <input type="radio" id="shape-private-y" name="shape-private" value="Y" onfocus="' + onfocusevent + '" onblur="' + onblurevent + '" onclick="' + onclickevent + ' document.selectedShape.lineobject.setPrivate(this.value);" ' + makedragable + '>' + shapeType_private
    + '<table style="width:100%; border-collapse:separate; white-space:nowrap; margin:7px 0 2px; _margin-top:5px" cellspacing="3" cellpadding="0">'
    + '<tr>'
    + '  <td style="text-align:left;">Line color:</td>'
    + '  <td style="text-align:left;"><div id="MM-currentlinecolor" style="width:15px; height:15px; border:1px solid #BFBFBF; background-color:' + this.linecolor + '; margin-right:5px; float:left; cursor:pointer;"  onclick="document.selectedShape.lineobject.setCommand(\'linecolor\');document.selectedShape.lineobject.showPallete(event)"></div></td>'
    + '  <td style="text-align:left; padding-left:5px;">Line opacity:</td>'
    + '  <td style="text-align:left;"><input type="text" value="' + this.lineopacity + '" style="width:30px; " onfocus="' + onfocusevent + '" onblur="' + onblurevent + ' document.selectedShape.lineobject.editCommand(\'lineopacity\',this.value);" onclick="' + onclickevent + '" ' + makedragable + '></td>'
    + '  <td style="text-align:left; padding-left:8px;">Line width:</td>'
    + '  <td style="text-align:left;"><input type="text" value="' + this.linewidth + '" style="width:30px; " onfocus="' + onfocusevent + '" onblur="' + onblurevent + ' document.selectedShape.lineobject.editCommand(\'linewidth\',this.value);" onclick="' + onclickevent + '" ' + makedragable + '></td>'
    + '</tr>';
        if (this.mode == 0) {
            detail += '<tr>'
      + '  <td style="text-align:left;">Fill color:</td>'
      + '  <td style="text-align:left;"><div id="MM-currentfillcolor"style="width:15px; height:15px; border:1px solid #BFBFBF; background-color:' + this.fillcolor + '; margin-right:5px; float:left; cursor:pointer;" onclick="document.selectedShape.lineobject.setCommand(\'fillcolor\');document.selectedShape.lineobject.showPallete(event)"></div></td>'
      + '  <td style="text-align:left; padding-left:5px;">Fill opacity:</td>'
      + '  <td style="text-align:left;"><input type="text" value="' + this.fillopacity + '" style="width:30px; " onfocus="' + onfocusevent + '" onblur="' + onblurevent + ' document.selectedShape.lineobject.editCommand(\'fillopacity\',this.value);" onclick="' + onclickevent + '" ' + makedragable + '></td>';
+'  <td></td><td></td>'
      + '</tr>'
        }
        detail += '</table>'
    + '<span style="cursor:pointer; text-decoration:underline; font-weight:bold; float:right; margin-right:5px;" onclick="noBubble(event);document.selectedShape.lineobject.clearLine();">Delete</span>'
    + '<span style="cursor:pointer; text-decoration:underline; font-weight:bold; float:right; margin-right:5px;" onclick="noBubble(event);document.selectedShape.lineobject.save();">Save</span>'
        //+'<span style="cursor:pointer; text-decoration:underline; font-weight:bold; float:right; margin-right:5px;" onclick=""><a target="_blank" href="shape/add?text='+encodeURIComponent(this.getJSONText())+'">Save</a></span>'
    + '</div>';
        var popup_param = { 'width': '316', 'height': '340', 'fixpopupsize': 'true' };
        this.mmmap.showPopUp(lat, longt, 'Edit shape style ', detail, popup_param);
        this.getPrivate() == "Y" ? document.getElementById("shape-private-y").checked = "checked" : document.getElementById("shape-private-n").checked = "checked";
    };
    this.switchPopupDisplay = function(show, hide) {
        if (show != '') document.getElementById(show).style.display = "block";
        if (hide != '') document.getElementById(hide).style.display = "none";
    };
    this.showPallete = function(e) {
        var position = this.getPalletePosition(e);
        var pallete = document.getElementById('MM-pallete');
        pallete.style.display = 'block';
        pallete.style.left = position.x + 'px';
        pallete.style.top = position.y + 'px';
    };
    this.hidePallete = function() {
        if (document.getElementById("MM-pallete")) document.getElementById("MM-pallete").style.display = 'none';
    };
    this.setCommand = function(cmd) {
        this.command = cmd;
    };
    this.setColor = function(color) {
        var temp = color.split('-');
        color = '#' + temp[1];
        this.selectedcolor = color;
        this.editCommand(this.command, this.selectedcolor);
        if (this.command == 'fillcolor') {
            this.fillcolor = color;
            this.canvas.canvas_fill_color = color;
            if (document.getElementById('MM-currentfillcolor') != null)
                document.getElementById('MM-currentfillcolor').style.backgroundColor = this.fillcolor;
        }
        else if (this.command == 'linecolor') {
            this.linecolor = color;
            this.canvas.canvas_line_color = color;
            if (document.getElementById('MM-currentlinecolor') != null)
                document.getElementById('MM-currentlinecolor').style.backgroundColor = this.linecolor;
            this.rePaintPointColor();
        }
    };
    this.setColor2 = function(color) {
        this.selectedcolor = color;
        this.editCommand(this.command, this.selectedcolor);
        if (this.command == 'fillcolor') {
            this.fillcolor = color;
            this.canvas.canvas_fill_color = color;
            if (document.getElementById('MM-currentfillcolor') != null)
                document.getElementById('MM-currentfillcolor').style.backgroundColor = this.fillcolor;
        }
        else if (this.command == 'linecolor') {
            this.linecolor = color;
            this.canvas.canvas_line_color = color;
            if (document.getElementById('MM-currentlinecolor') != null)
                document.getElementById('MM-currentlinecolor').style.backgroundColor = this.linecolor;
            this.rePaintPointColor();
        }
    };
    this.rePaintPointColor = function() {
        for (var i = 0; i < this.lineseq.length; i++) {
            var point = this.mmmap.getCustomDiv(this.lineseq[i]);
            point.style.border = "1px solid " + this.linecolor;
        }
        for (var i = 0; i < this.mDivArray.length; i++) {
            var point = this.mmmap.getCustomDiv(this.mDivArray[i][4]);
            point.style.border = "1px solid " + this.linecolor;
        }
    };
    this.editCommand = function(cmd, value) {
        if (value == '') return false;
        var shape = document.selectedShape;
        if (typeof (shape) != 'undefined' && shape != '') {
            uv_v = document.getElementById("_mmmap_vector_div");
            if (typeof (uv_v.gs) == 'undefined') {
                uv_v.gs = new allgs(uv_v);
            }
            uv_v.gs.editCommand(shape, cmd, value);
            if (cmd == 'linewidth') {
                this.linewidth = value;
                this.canvas.canvas_line_width = value;
            } else if (cmd == 'fillopacity') {
                this.fillopacity = value;
                this.canvas.canvas_fill_opac = value;
            } else if (cmd == 'lineopacity') {
                this.lineopacity = value;
                this.canvas.canvas_line_opac = value;
            }
        }
        this.hidePallete();
    };
    this.getPalletePosition = function(e) {
        var e = e || window.event;
        var cursor = { x: 0, y: 0 };
        if (e.pageX || e.pageY) {
            cursor.x = e.pageX - 2;
            cursor.y = e.pageY - 2;
        }
        else {
            cursor.x = e.clientX - 2;
            cursor.y = e.clientY - 2;
        }
        return cursor;
    };
    this.setLineColor = function(value) {
        this.linecolor = value;
    };
    this.setLineWidth = function(value) {
        this.linewidth = value;
    };
    this.setFillColor = function(value) {
        this.fillcolor = value;
    };
    this.setLineOpacity = function(value) {
        this.lineopacity = value;
    };
    this.setFillOpacity = function(value) {
        this.fillopacity = value;
    };
    this.getLineColor = function() {
        return this.linecolor;
    };
    this.getLineWidth = function() {
        return this.linewidth;
    };
    this.getFillColor = function() {
        return this.fillcolor;
    };
    this.getLineOpacity = function() {
        return this.lineopacity;
    };
    this.getFillOpacity = function() {
        return this.fillopacity;
    };
    this.newAjaxRequest = function() {
        var xmlreq = false;
        if (window.XMLHttpRequest) {
            xmlreq = new window.XMLHttpRequest();
        }
        else if (window.ActiveXObject) {
            try {
                xmlreq = new ActiveXObject("Msxml2.XMLHTTP");
            } catch (e1) {
                try {
                    xmlreq = ActivXObject("Microsoft.XMLHTTP");
                } catch (e2) {
                    xmlreq = false;
                }
            }
        }
        return xmlreq;
    };
    this.getReadyStateHandler = function(req, responseXmlHandler) {
        return function() {
            if (req.readyState == 4) {
                if (req.status == 200) {
                    responseXmlHandler(req.responseText);
                }
                else {
                    alert('Failed to send data to the server.');
                }
            }
        };
    };
    this.ajax = function(URL, parameters, _callBack, obj) {
        var ajax = new obj.newAjaxRequest();
        if (_callBack) {
            ajax.onreadystatechange = obj.getReadyStateHandler(ajax, _callBack);
        }
        ajax.open("POST", URL, true);
        ajax.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        if (typeof (extendParameters) != 'undefined') {
            ajax.send(parameters + '&' + Math.random() + '&' + extendParameters);
        }
        else {
            ajax.send(parameters + '&' + Math.random());
        }
    };
    this.setDescription = function(content) {
        this.user_defined_popup_content = content;
    };
    this.getDescription = function() {
        return this.user_defined_popup_content;
    };
    this.setTitle = function(title) {
        this.user_defined_title = title;
    };
    this.getTitle = function() {
        return this.user_defined_title;
    };
    this.setDescriptionTh = function(content) {
        this.description_th = content;
    };
    this.getDescriptionTh = function() {
        return this.description_th;
    };
    this.setDescriptionEn = function(content) {
        this.description_en = content;
    };
    this.getDescriptionEn = function() {
        return this.description_en;
    };
    this.setTitleTh = function(title) {
        this.title_th = title;
    };
    this.getTitleTh = function() {
        return this.title_th;
    };
    this.setTitleEn = function(title) {
        this.title_en = title;
    };
    this.getTitleEn = function() {
        return this.title_en;
    };
    this.setShortDescriptionTh = function(content) {
        this.shortdescription_th = content;
    };
    this.getShortDescriptionTh = function() {
        return this.shortdescription_th;
    };
    this.setShortDescriptionEn = function(content) {
        this.shortdescription_en = content;
    };
    this.getShortDescriptionEn = function() {
        return this.shortdescription_en;
    };
    this.setPrivate = function(type) {
        this.private = type;
    };
    this.getPrivate = function() {
        return this.private;
    };
    this.showUserDefinedPopup = function(content) {
        var lat;
        var longt;
        if (typeof (_lat) == 'undefined' || typeof (_lon) == 'undefined') {
            lat = this.mmmap.mouseCursorLat();
            longt = this.mmmap.mouseCursorLong();
        }
        this.mmmap.showPopUp(lat, longt, this.user_defined_title, content);
    };
    this.setMode = function(mode) {
        this.modeintext = mode;
        switch (mode) {
            case "polygon": this.mode = 0; break;
            case "line": this.mode = 1; break;
            case "ellipse": this.mode = 3; break;
        }
    };
    this.getMode = function() {
        return this.modeintext;
    }
    this.removeVector = function() {
        this.mmmap.removeVector(this.lineID);
    };
    this.setEdit = function(bool) {
        this.enableedit = bool;
        this.logic = bool;
        if (this.logic) {
            this.setPoints(this.point);
        }
        this.setListenToEvents(false);
    };
    this.setLabel = function(label) {
        this.label = label;
        this.drawLabel();
    };
    this.setCenter = function(lat, lng) {
        this.centerlat = lat;
        this.centerlng = lng;
    };
    this.getCenter = function() {
        var coor = { latitude: 0, longitude: 0 };
        coor.latitude = this.centerlat;
        coor.longitude = this.centerlng;
        return coor;
    };
    this.drawLabel = function() {
        var center = this.getCenter();
        if (center.latitude == 0 || center.longitude == 0) {
            return false;
        }
        this.removeLabel();
        var labeldiv = document.createElement("div");
        labeldiv.innerHTML = "<center>" + this.label + "</center>";
        labeldiv.style.width = "200px";
        if (this.getDescription() != '') {
            labeldiv.style.cursor = "pointer";
            labeldiv.lineobject = this;
            labeldiv.onclick = function() { this.lineobject.showUserDefinedPopup(this.lineobject.getDescription()); }
        }
        this.labeldiv = '' + this.mmmap.drawCustomDiv(labeldiv, center.latitude, center.longitude, "");
        labeldiv.id = 'mmline-label-' + this.labeldiv;
        labeldiv.style.zIndex = 0;
    };
    this.removeLabel = function() {
        if (this.labeldiv != '') {
            this.mmmap.removeCustomDivs(this.labeldiv);
            this.labeldiv = '';
        }
    };
    this.showEditPopup = function(bool) {
        this.showeditpopup = bool;
    };
    this.getArea = function(showunit) {
        if (this.mode != 0) return 0;
        if (typeof (showunit) == 'undefined') showunit = true;
        var resolution = Math.pow(2, this.lineObject.mmmap.getZoom());
        var count = this.linepoint.length;
        var tally = 0;
        var i;
        var points = this.linepoint;
        points[count] = points[0];
        for (i = 0; i < count; i++) {
            tally += (points[i + 1][0]) * (points[i][1]);
            tally -= (points[i][0]) * (points[i + 1][1]);
        }
        points.pop();
        var result = (mylang == "en") ? "about " : "ประมาณ ";
        var unit = (mylang == "en") ? ' sq. km' : " ตร.กม.";
        var area = (Math.abs(tally) * 0.5 * this.mmmap.getKmPerLat() * this.mmmap.getKmPerLong());
        if (area < 0.1) {
            area = area * 1000000;
            unit = (mylang == "en") ? ' sq. m' : " ตร.ม.";
        }
        this.area = area;
        area += '';

        if (showunit) {
            area = this.addCommas(area);
            area = area.substr(0, area.indexOf('.') + 3);
            return result += area + unit;
        }
        else return area;
    };
    this.getAreaRai = function(format) {
        if (this.mode != 0) return 0;
        var area = this.area;
        if (typeof (format) == 'undefined') format = true;
        if (format) {
            area = area * 1000000;
            var unitrai;
            var unitngarn;
            var unitwa;
            var prefix;
            if (mylang == "en") {
                unitrai = ' Rai';
                unitngarn = ' Ngarn';
                unitwa = ' sq. Wa';
                prefix = 'About '
            }
            else {
                prefix = 'ประมาณ ';
                if (format == 'short') {
                    unitrai = ' ไร่';
                    unitngarn = ' ง.';
                    unitwa = ' ตร.ว.';
                }
                else {
                    unitrai = ' ไร่';
                    unitngarn = ' งาน';
                    unitwa = ' ตร.ว.';
                }
            }
            var rai = this.addCommas(parseInt(area / (400 * 4))) + unitrai;
            var rest = area % (400 * 4);
            var ngarn = parseInt(rest / (100 * 4)) + unitngarn;
            rest = rest % (100 * 4);
            var wa = parseInt(rest / 4) + unitwa;
            area = (format != 'short') ? prefix + rai + ' ' + ngarn + ' ' + wa : '(' + rai + ' ' + ngarn + ' ' + wa + ')';
        }
        return area;
    };
    this.contain = function(point) {
        if (typeof (point) == 'undefined') return 'invalid parameter';
        if (!point.latitude || !point.longitude) return 'invalid parameter';
        var inside = false;
        var findY = point.latitude; /*latitude*/
        var findX = point.longitude; /*longitude*/

        if (this.mode == 0) {
            var i, j = this.linepoint.length - 1;
            for (i = 0; i < this.linepoint.length; i++) {
                if (this.linepoint[i][0] < findX && this.linepoint[j][0] >= findX || this.linepoint[j][0] < findX && this.linepoint[i][0] >= findX) {
                    if (this.linepoint[i][1] + (findX - this.linepoint[i][0]) / (this.linepoint[j][0] - this.linepoint[i][0]) * (this.linepoint[j][1] - this.linepoint[i][1]) < findY) {
                        inside = !inside;
                    }
                }
                j = i;
            }
        }
        else if (this.mode == 3) {
            var width = this.getWidth();
            var height = this.getHeight();
            var y = this.getCenter().latitude;
            var x = this.getCenter().longitude;
            var xdiff = (x - findX) * this.mmmap.getKmPerLong();
            var ydiff = (y - findY) * this.mmmap.getKmPerLat();
            var rx = this.getWidth();
            var ry = this.getHeight();
            var result = Math.pow(xdiff, 2) / Math.pow(rx, 2) + Math.pow(ydiff, 2) / Math.pow(ry, 2);
            if (result < 1) inside = true;
        }
        return inside;
    };
    this.setOrder = function(num) {
        if (typeof (num) != 'number') return false;
        this.zIndex = num;
        if (document.getElementById('mmline-label-' + this.labeldiv) != null)
            document.getElementById('mmline-label-' + this.labeldiv).style.zIndex = num;
    };
    this.rePaint = function() {
        if (!this.vector) {
            return false;
        }
        var shape = this.vector.shape;
        var uv_v = document.getElementById("_mmmap_vector_div");
        if (typeof (uv_v.gs) != 'undefined') {
            uv_v.gs.editCommand(shape, 'fillcolor', this.fillcolor);
            uv_v.gs.editCommand(shape, 'linecolor', this.linecolor);
            uv_v.gs.editCommand(shape, 'linewidth', this.linewidth);
            uv_v.gs.editCommand(shape, 'lineopacity', this.lineopacity);
            uv_v.gs.editCommand(shape, 'fillopacity', this.fillopacity);
        }
        if (typeof (shape) != 'undefined' && typeof (shape.renderer) != 'undefined' && shape.renderer == 'vml') {
            shape.style.zIndex = this.zIndex;
        }
        else {
            if (typeof (this.allvector) != 'undeined') {
                for (var i = 0; i < this.allvector.length - 1; i++) {
                    if (this.allvector[i].enable) {
                        for (var j = i + 1; j < this.allvector.length; j++) {
                            if (typeof (this.allvector[j]) != 'undeined' && this.allvector[j].enable) {
                                if (typeof (this.allvector[j].lineobject) != 'undefined' && this.allvector[j].lineobject && (typeof (this.allvector[i].lineobject) != 'undefined' && this.allvector[j].lineobject.zIndex < this.allvector[i].lineobject.zIndex)) {
                                    /*var temp = this.allvector[j];
                                    this.allvector[j] = this.allvector[i];
                                    this.allvector[i] = temp;*/
                                }
                            }
                        }
                    }
                }
                this.mmmap.reDrawLines();
            }
        }
    };
    this.zSwap = function(elem1, elem2) {
        var parent = elem1.parentNode;
        var tmp = elem1.cloneNode(true);
        parent.replaceChild(tmp, elem2);
        parent.replaceChild(elem2, elem1);
    };
    this.setWidth = function(w) {
        if (this.mode != 3) return;
        this.width = w;
    };
    this.setHeight = function(h) {
        if (this.mode != 3) return;
        this.height = h;
    };
    this.getWidth = function(w) {
        if (this.mode != 3) return;
        return this.width;
    };
    this.getHeight = function(h) {
        if (this.mode != 3) return;
        return this.height;
    };
    this.hide = function() {
        if (!this.vector) return false;
        var shape = (this.vector.shape.length) ? this.vector.shape[0] : this.vector.shape;
        shape.style.visibility = 'hidden';
        this.vector.show = false;
    }
    this.show = function() {
        if (!this.vector) return false;
        var shape = (this.vector.shape.length) ? this.vector.shape[0] : this.vector.shape;
        shape.style.visibility = 'visible';
        this.vector.show = true;
    }
    this.remove = function() {
        if (!this.vector) {
            this.mmmap.removeVector(this.lineID);
            return;
        }
        var shape = (typeof (this.vector.shape) != 'undefined' && this.vector.shape.length) ? this.vector.shape[0] : this.vector.shape;
        if (shape && shape.parentNode != null) {
            shape.parentNode.removeChild(shape);
            this.vector.enable = false;
        }
    }
    document.lineObject = this;
    if (!document.initdrawpolygon) {
        if (window.addEventListener) {
            document.addEventListener('mouseup', this.checkDragMap, false);
            document.addEventListener('mousedown', this.checkmousedown, false);
            document.initdrawpolygon = true;
        } else {
            document.attachEvent('onmouseup', this.checkDragMap);
            document.attachEvent('onmousedown', this.checkmousedown);
            document.initdrawpolygon = true;
        }
    }
    this.defaultMoveMapWhenDBLClicked = this.mmmap.getMoveMapWhenDBLClicked();
    this.mmmap.setMoveMapWhenDBLClicked(false);

    // Tracker & Pointer
    this.getTracker = function() {
        new MMLineTracker(this.mmmap, this.getLineArray());
        return mmlinetracker;
    }

    this.getPointer = function() {
        new MMLinePointer(this.mmmap, this.getLineArray());
        return mmlinepointer;
    }

    this.setHandler = function(handler) {
        this.handler = handler;
    }
}
function MMMapObject(mymmmap, myid, ds, showdefaulttitle, forcetitle, forcemode, linecolor, fillcolor, linetransp, filltransp, dozoom) {

    this.mmmap = mymmmap;

    if (!mymmmap || !myid) {
        return null;
    }

    this.instanceid = MMMapObject.instances.length;
    MMMapObject.instances[MMMapObject.instances.length] = this;

    this.gsobjects = new Array();
    this.centerlat = null;
    this.centerlng = null;
    this.showdefaulttitle = showdefaulttitle;

    this.getGSObjects = function() {
        return this.gsobjects;
    }

    this.rePaint = function() {
        if (!this.data) return;
        var sresult = this.data;
        if (!sresult.meta) return;

        if (sresult.meta && sresult.meta.objtype == "ooi") {
            if (sresult.meta.noobjects && sresult.meta.noobjects > 0) {
                var poi = sresult.data;
                var id = poi.id;
                var name = poi.name;
                var name_en = poi.name_en;
                var lat = poi.lat;
                var mylong = poi.long;
                var type = poi.type;
                var status = poi.status;
                var showlevel = poi.showlevel;

                var dozoom = sresult.meta.dozoom;

                var usename = name;
                if (mylang == "en") {
                    if (name_en != "")
                        usename = name_en;
                    else
                        usename = "(Thai) " + name;
                }

                markPOI(id, usename, lat, mylong, showlevel, "");
                if (dozoom == "1") {
                    mmmap.setZoom(showlevel);
                }
            }
        } else {
            this.gsobjects = new Array();

            var linearray = [];
            var keyword = sresult.meta.keyword;
            linearray = sresult.data.linearray;
            var loopto = linearray.length;

            this.mmmap.gssetlinewidth(4);
            //this.mmmap.gssetcolor("#FF83CD");

            var comments_label = new Array();

            for (var i = 0; i < loopto; i++) {
                if (linearray[i] && linearray[i].data.length > 1) {
                    var mytitle;
                    if (window.locale && locale == "en") {
                        mytitle = linearray[i].name_e;
                    } else {
                        mytitle = linearray[i].name_t;
                    }

                    var drawmode = linearray[i].mode;
                    var myid = linearray[i].myid;
                    var mylinecolor = "FF83CD";
                    var mylinecolortransp = 0.6;
                    var myfillcolor = "FF83CD";
                    var myfillcolortransp = 0.6;

                    if (linearray[i].linecolor && linearray[i].linecolor != "") {
                        mylinecolor = linearray[i].linecolor;
                        if (linearray[i].linecolor.length > 6) {
                            linearray[i].linecolor = linearray[i].linecolor.replace('#', '');
                            mylinecolortransp = parseInt(linearray[i].linecolor.substr(6), 16) / 256.0;
                            mylinecolor = linearray[i].linecolor.substr(0, 6);
                        }
                    }
                    if (linearray[i].fillcolor && linearray[i].fillcolor != "") {
                        drawmode = "polygon";
                        myfillcolor = linearray[i].fillcolor;
                        if (linearray[i].fillcolor.length > 6) {
                            linearray[i].fillcolor = linearray[i].fillcolor.replace('#', '');
                            myfillcolortransp = parseInt(linearray[i].fillcolor.substr(6), 16) / 256.0;
                            myfillcolor = linearray[i].fillcolor.substr(0, 6);
                        }
                    }

                    if (linearray[i].linetransp && linearray[i].linetransp != "") {
                        mylinecolortransp = linearray[i].linetransp;
                    }
                    if (linearray[i].filltransp && linearray[i].filltransp != "") {
                        myfillcolortransp = linearray[i].filltransp;
                    }

                    mylinecolor = "#" + mylinecolor;
                    myfillcolor = "#" + myfillcolor;



                    /*
                    mmmap.gssetcolor(mylinecolor);
                    mmmap.gssetopacity(mylinecolortransp);
                    // mmmap.drawPolyline (points, startzoom,stopzoom,title,detail, detailpopup, pointmode, lineobject) 
                    mmmap.drawPolyline(linearray[i].data, 1, 14, mytitle, mytitle);
                    */

                    var polygon = new MMLine(this.mmmap);
                    polygon.setMode(drawmode); // line or polygon
                    polygon.setLineColor(mylinecolor);
                    polygon.setLineWidth(4);
                    polygon.setLineOpacity(mylinecolortransp); // 0-1
                    if (drawmode == "polygon") {
                        polygon.setFillColor(myfillcolor);
                        polygon.setFillOpacity(myfillcolortransp); // 0-1
                    }
                    polygon.setCenter(linearray[i].centerlat, linearray[i].centerlong);

                    if (this.showdefaulttitle && !comments_label[mytitle]) {
                        polygon.setLabel('<font size=-1>' + mytitle + "</font>");
                        comments_label[mytitle] = "d"; //drawn
                        polygon.setDescription("Name: " + linearray[i].name_t + ", " + linearray[i].name_e + "<br>ID: " + myid);
                    }

                    polygon.setTitle(mytitle);
                    polygon.setPointsLongLat(linearray[i].data);

                    this.gsobjects[this.gsobjects.length] = polygon;
                }
            }
            try {
                this.centerlat = linearray[0].centerlat;
                this.centerlng = linearray[0].centerlng;
            }
            catch (e) { }
        }
    }

    this.moveToMe = function() {
        if (this.centerlat && this.centerlng) {
            this.mmmap.moveTo(this.centerlat, this.centerlng);
        }
    }

    // Constructor
    var optargs = "&zoom=" + this.mmmap.getZoom();

    if (ds == "LONGDO" && myid.match(/^A/)) {
        // OOI
        var d = new Date;
        var timestamp = d.getTime();
        if (!dozoom) dozoom = false;

        optargs += "&timestamp=" + encodeURIComponent(timestamp);
        optargs += "&dozoom=" + dozoom;

    } else {
        // non-OOI

        if (forcetitle && forcetitle != "") {
            optargs += "&forcetitle=" + forcetitle;
        }
        if (forcemode && forcemode != "") {
            optargs += "&forcemode=" + forcemode;
        }
        if (linecolor && linecolor != "") {
            optargs += "&forcelinecolor=" + linecolor;
        }
        if (fillcolor && fillcolor != "") {
            optargs += "&forcefillcolor=" + fillcolor;
        }
        if (linetransp && linetransp != "") {
            optargs += "&forcelinetransp=" + linetransp;
        }
        if (filltransp && filltransp != "") {
            optargs += "&forcefilltransp=" + filltransp;
        }

        myid = encodeURIComponent(myid);
        ds = encodeURIComponent(ds);

    }

    var tmpvarname = "MMMapObject.getInstance(" + this.instanceid + ")";
    loadJSON('http://mmmap15.longdo.com/search/rpc-json.php?key=d9c8884535ae82504c4962ce47a4cae4&mode=json&action=showObject&objid=' + myid + '&ds=' + ds + optargs + '&var=' + tmpvarname + '.data&callback=' + tmpvarname + '.rePaint()');

    return this;
}

MMMapObject.instances = new Array();
MMMapObject.getInstance = function(idx) {
    if (idx < MMMapObject.instances.length) {
        return MMMapObject.instances[idx];
    }
    return null;
}

MMMap.prototype.showObject = function(myid, ds, showdefaulttitle, forcetitle, forcemode, linecolor, fillcolor, linetransp, filltransp) {
    return new MMMapObject(this, myid, ds, showdefaulttitle, forcetitle, forcemode, linecolor, fillcolor, linetransp, filltransp);
}

MMMap.prototype.myShowLocationDetail = null;
MMMap.prototype.setMyShowLocationDetail = function(f) {
    this.myShowLocationDetail = f;
}

MMMap.prototype.showLocationDetail = function(id, popup_idx) {
    showDiv("locationdetails_contents", '<font color=brown>Loading...</font>');
    var d = new Date;
    var timestamp = d.getTime();

    var pars = "id=" + encodeURIComponent(id)
    + "&timestamp=" + encodeURIComponent(timestamp)
    + "&locale=" + mylang
    + "&timestamp=" + encodeURIComponent(timestamp)
    + "&action=showpoidetails"
    + "&mode=json"

    var rand = Math.floor(Math.random() * 1000000);
    json_request("http://mmmap15.longdo.com/search/rpc-json.php", pars + "&key=d9c8884535ae82504c4962ce47a4cae4", "__MMMAP_showLocationDetail_result_" + rand, "mmmap.showLocationDetail_process(__MMMAP_showLocationDetail_result_" + rand + ", " + popup_idx + ");");
}

MMMap.prototype.showLocationDetail_process = function(sresult, popup_idx) {
    if (sresult) {
        showDiv("locationdetails_contents", sresult);
        mmmap.updatePopupContents(popup_idx);
    }
}

//ms22.longdo.com

var browser;

var mymap;
var mymaparea;
var _mmmap_div;
var mylang = "th";

var latitude;
var longitude;
var resolution;


function showDiv(divname, contents) {
    if (window.document.getElementById(divname) != null) {
        window.document.getElementById(divname).innerHTML = contents;
    }
}

function convertLatLongToPoint(_lat, _long, _zoom) {
    var myres = Math.pow(2, _zoom);

    degree_to_pixel = (imagewidth * myres) / longitude_range;

    var result = new Object();

    var centerposx = parseInt((longitude - minlongitude) / longitude_range * myres);
    var centerposy = parseInt((maxlatitude - latitude) * degree_to_pixel / imageheight);

    result.imgid = centerposy * myres + centerposx;

    result.x = longToPoint(longitude, myres);
    result.y = latToPoint(latitude, myres);

    return result;
}

function linkToPage(extraparams) {
    var url = "?";

    if (mmmap.currentmode == "gmap" || mmmap.currentmode == "hybrid") {
        url = url + "gmap=1&";

        if (mmmap.currentmode == "hybrid") {
            url = url + "hybrid=1&";
        }

        url = url + "gmap=1&";

        latitude = gmap.gmap_object.getCenter().lat();
        longitude = gmap.gmap_object.getCenter().lng();

        resolution = res_g2m(gmap.gmap_object.getZoom());

        if (resolution > 32768) resolution = 32768;
        if (resolution < 1) resolution = 1;
    }

    url = url + 'lat=' + latitude + '&long=' + longitude + '&res=' + resolution + '&mode=' + mmmap.mapmode + '&map=ms22';

    if (mylang) {
        url += '&locale=' + mylang;
    }

    if (extraparams) {
        url += extraparams;
    }

    window.location = url;
}

function findObjPos(obj) {
    var curleft = curtop = 0;
    if (obj.offsetParent) {
        curleft = obj.offsetLeft
        curtop = obj.offsetTop
        while (obj = obj.offsetParent) {
            curleft += obj.offsetLeft
            curtop += obj.offsetTop
        }
    }
    return [curleft, curtop];
}

function showMMMap() {
    if (!document.getElementById("mmmap_div")) {
        window.location = "/";
        return;
    }

    if (mmmap.currentmode == "mm") {
        return;
    }
    mmmap.currentmode = "mm";

    mresolution = res_g2m(gmap.gmap_object.getZoom());
    if (mresolution > 32768) mresolution = 32768;
    if (mresolution < 1) mresolution = 1;

    latitude = gmap.gmap_object.getCenter().lat();
    longitude = gmap.gmap_object.getCenter().lng();

    mmmap.setCenter(latitude, longitude, mresolution);

    mymaparea.style.visibility = "visible";
    resolution_bar_div.style.visibility = "visible";
    span_current_resolution_text_div.style.visibility = "visible";

}

function hookEvent(element, eventName, callback) {
    if (typeof (element) == "string")
        element = document.getElementById(element);
    if (element == null)
        return;
    if (element.addEventListener) {
        if (eventName == 'mousewheel')
            element.addEventListener('DOMMouseScroll', callback, false);
        element.addEventListener(eventName, callback, false);
    }
    else if (element.attachEvent)
        element.attachEvent("on" + eventName, callback);
}


function unhookEvent(element, eventName, callback) {
    if (typeof (element) == "string")
        element = document.getElementById(element);
    if (element == null)
        return;
    if (element.removeEventListener) {
        if (eventName == 'mousewheel') {
            element.removeEventListener('DOMMouseScroll',
					callback, false);
        }
        element.removeEventListener(eventName, callback, false);
    }
    else if (element.detachEvent)
        element.detachEvent("on" + eventName, callback);
}

function cancelEvent(e) {
    e = e ? e : window.event;
    if (e.stopPropagation)
        e.stopPropagation();
    if (e.preventDefault)
        e.preventDefault();
    e.cancelBubble = true;
    e.cancel = true;
    e.returnValue = false;
    return false;
}

function acceptWheel(element, handler) {
    hookEvent(element, 'mousewheel', handler);
}

function muteWheel(element, handler) {
    unhookEvent(element, 'mousewheel', handler);
}

function findBodyOffset() {
    var offsetx;
    var offsety;
    if (browser == "IE") {  // IE
        offsetx = document.body.scrollLeft;
        offsety = document.body.scrollTop;
    }
    else {
        offsetx = window.scrollX;
        offsety = window.scrollY;
    }

    return { 'offsetx': offsetx, 'offsety': offsety };
}

function findPosX(obj) {
    return parseInt(parseFloat(obj.style.left.replace("px", "")));
}

function findPosY(obj) {
    return parseInt(parseFloat(obj.style.top.replace("px", "")));
}

function longToPoint(mylong, _resolution) {
    var degree_to_pixel = (imagewidth * _resolution) / longitude_range;
    var x = parseInt((mylong - minlongitude) * degree_to_pixel);
    return x;
}

function latToPoint(lat, _resolution) {
    var degree_to_pixel = (imagewidth * _resolution) / longitude_range;
    var y = parseInt((maxlatitude - lat) * degree_to_pixel);
    return y;
}

function pointToLong(x, _resolution) {
    var degree_to_pixel = (imagewidth * _resolution) / longitude_range;
    if (window.mmmap) x += mmmap.mapoffset.x;
    return (x / degree_to_pixel + minlongitude);
}

function pointToLat(y, _resolution) {
    var degree_to_pixel = (imagewidth * _resolution) / longitude_range;
    if (window.mmmap) y += mmmap.mapoffset.y;
    return (maxlatitude - y / degree_to_pixel);
}

function chkWinSize() {
    if (navigator.appVersion.charAt(0) >= 4) {
        if (browser == "IE") {  // IE
            ww = document.body.clientWidth;
            wh = document.documentElement.clientHeight;
            if (wh == 0) {
                wh = document.body.clientHeight;
            }
        } else if ((document.layers) || (document.getElementById)) {
            ww = window.innerWidth;
            wh = window.innerHeight;
        }
    }
}

function addEvent(obj, evType, fn) {
    if (obj.addEventListener) {
        obj.addEventListener(evType, fn, false);
        return true;
    } else if (obj.attachEvent) {
        var r = obj.attachEvent("on" + evType, fn);
        return r;
    } else {
        return false;
    }
}

function createCookie(name, value, days) {
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        var expires = "; expires=" + date.toGMTString();
    }
    else var expires = "";
    document.cookie = name + "=" + value + expires + "; path=/";
}

function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function MMMap(_div, _latitude, _longitude, _zoom, _mapmode) {

    this.mapdiv = _div;
    _mmmap_div = _div;

    this.maxlatitude = 23.3075;
    this.minlatitude = 2.2325;
    this.maxlongitude = 114.9962;
    this.minlongitude = 86.8962;

    this.ovl_images = new Array();
    this.ovl_enable = false;

    this.ovl_servername = "ms22.longdo.com/mmmap";

    this.mapvector = new Array(false);

    this.do_search = function(offset, word, ddiv) {
        do_search(offset, word, ddiv);
    }

    if (this.mapdiv.style.width == "") {
        this.mapdiv.style.width = "500px";
    }
    if (this.mapdiv.style.height == "") {
        this.mapdiv.style.height = "400px";
    }

    this.showpoi = 100000; // whether to show POI or not, specified by the starting resolution that the POI should be shown
    this.usesuppliedicons = true;

    this.currentmode = "mm"; // or google

    this.showlocationdescription = true;

    latitude = _latitude;
    longitude = _longitude;
    this.zoom = _zoom;
    resolution = Math.pow(2, this.zoom);

    // set up div contents

    _div.innerHTML = '<!-- CENTER POINT --> <div id="MMMAP_center_point" style="position:absolute; visibility: hidden; z-index:500;-moz-user-select: none;user-select: none;-khtml-user-select: none"> <img src="http:\/\/mmmap15.longdo.com\/\/mmmap\/images\/red-mark.gif" border=0 galleryimg=no oncontextmenu="return false" style="z-index:3;-moz-user-select: none"> <\/div>  <div id="maparea" style="z-index: 0;   background-color: #dbdbdb;  border: 1pt;  position: absolute;  overflow:hidden; " > <div id="id_mymap"   style="z-index: 1;   position: relative;  left: 0; top: 0; " > <!-- POP-UP --> <div id=context_menu style=\'position:absolute;background-color:#c8c8c8;color:black;visibility:hidden;z-index:800;\'><\/div> <div id=location_detail_popup style=\'position:absolute;color:black;visibility:hidden;z-index:900;overflow:hidden;\'>   <font size=-1>       <div id=\'popup_top\' style=\'height:35px;\'>       <div id=\'popup_top_left\' style=\'background:url(http:\/\/mmmap15.longdo.com\/\/mmmap\/images\/popup\/popup-top-left.png) no-repeat; width:20px; height:35px; float:left;\'><\/div>       <div id=\'location_contents_title\' style=\'background:url(http:\/\/mmmap15.longdo.com\/\/mmmap\/images\/popup\/popup-top.png) repeat-x; overflow: hidden; height:100%; float:left; width:auto;\' nowrap><\/div>       <div id=\'popup_top_right\' style=\'background:url(http:\/\/mmmap15.longdo.com\/\/mmmap\/images\/popup\/popup-top-right.png) no-repeat scroll; width:35px; height:100%; float:left; text-align:right;\'\'>         <span id=\'close_location_popup\' style=\'cursor:pointer; position:relative; right:18px; top:14px;\'><img src=\'http:\/\/mmmap15.longdo.com\/\/mmmap\/images\/popup\/cross-red.png\' onmouseout=\'this.src="http:\/\/mmmap15.longdo.com\/\/mmmap\/images\/popup\/cross-red.png"\' onmouseover=\'this.src="http:\/\/mmmap15.longdo.com\/\/mmmap\/images\/popup\/cross-gray.png"\'><\/span>       <\/div><\/div>       <div id=\'popup_title\'><\/div>       <div id=\'popup_middle\'>       <div id=\'popup_middle_left\' style=\'background:url(http:\/\/mmmap15.longdo.com\/\/mmmap\/images\/popup\/popup-left.png) repeat-y; width:16px; height:100%; float:left;\'><\/div>       <div id=\'locationdetails_contents\' style=\'overflow:hidden; background:white; float:left; height:100%;\' onmouseup=\'return false\'><\/div>       <div id=\'popup_middle_right\' style=\'background:url(http:\/\/mmmap15.longdo.com\/\/mmmap\/images\/popup\/popup-right.png) repeat-y; width:24px; height:100%; float:left;\'><\/div><\/div>       <div id=\'popup_bottom\' style=\'height:60px;\'\'>       <div id=\'popup_bottom_left\' style=\'background:url(http:\/\/mmmap15.longdo.com\/\/mmmap\/images\/popup\/popup-bottom-left.png) no-repeat scroll; width:55px; height:100%; float:left;\'><\/div>       <div id=\'locationdetails_contents_bottom\' style=\'background:url(http:\/\/mmmap15.longdo.com\/\/mmmap\/images\/popup\/popup-bottom.png) repeat-x; height:100%; float:left;\'><div id=\'locationdetails_attaches\' style=\'white-space:nowrap;\'><\/div><\/div>       <div id=\'popup_bottom_right\' style=\'background:url(http:\/\/mmmap15.longdo.com\/\/mmmap\/images\/popup\/popup-bottom-right.png) no-repeat scroll; width:25px; height:100%; float:left;\'><\/div>       <div id=\'locationdetails_contents_scroll_arrow\' style=\'position:absolute; bottom:44px;\'><\/div><\/div>   <\/font> <\/div> <span id=tmp_contents style=\'float:right; visibility:hidden;\'><\/span>  <div id="_mmmap_texttip" defaultdelay="200" style="display: none;font: 8pt \'Tahoma\';position: absolute; background-image: url(http:\/\/mmmap15.longdo.com\/mmmap\/images\/blank.gif);z-index:1000;"><\/div>  <div id=current_roads_div style=\'position:absolute;z-index:500;left: 0; top:0\'><\/div> <div id=custom_div style=\'position:absolute;z-index:500;left: 0; top:0\'><\/div> <div id=_mmmap_editing_div style=\'position:absolute;z-index:490;left: 0; top:0\'><\/div> <div id=_mmmap_vector_div style=\'position:absolute;z-index:450;left: 0; top:0\'><\/div>   <!-- MARKER --> <div id=\'mark_point1\' style=\'position:absolute;visibility:hidden;z-index:500;\'><\/div> <div id=\'mark_point2\' style=\'position:absolute;visibility:hidden;z-index:500;\'><\/div> <div id=\'mark_point3\' style=\'position:absolute;visibility:hidden;z-index:500;\'><\/div> <div id=\'mark_point4\' style=\'position:absolute;visibility:hidden;z-index:500;\'><\/div> <div id=\'mark_point5\' style=\'position:absolute;visibility:hidden;z-index:500;\'><\/div> <div id=\'mark_point6\' style=\'position:absolute;visibility:hidden;z-index:500;\'><\/div> <div id=\'mark_point7\' style=\'position:absolute;visibility:hidden;z-index:500;\'><\/div> <div id=\'mark_point8\' style=\'position:absolute;visibility:hidden;z-index:500;\'><\/div> <div id=\'mark_point9\' style=\'position:absolute;visibility:hidden;z-index:500;\'><\/div> <div id=\'mark_point10\' style=\'position:absolute;visibility:hidden;z-index:500;\'><\/div> <div id=\'mark_point11\' style=\'position:absolute;visibility:hidden;z-index:500;\'><\/div> <div id=\'mark_point12\' style=\'position:absolute;visibility:hidden;z-index:500;\'><\/div> <div id=\'mark_point13\' style=\'position:absolute;visibility:hidden;z-index:500;\'><\/div> <div id=\'mark_point14\' style=\'position:absolute;visibility:hidden;z-index:500;\'><\/div> <div id=\'mark_point15\' style=\'position:absolute;visibility:hidden;z-index:500;\'><\/div>  <div id="div_id_img0" style="position: absolute; overflow: hidden; left: 0px; top: 0px; width: 320px; height: 240px "><img id="blur_id_img0" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img0" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img1" style="position: absolute; overflow: hidden; left: 320px; top: 0px; width: 320px; height: 240px "><img id="blur_id_img1" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img1" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img2" style="position: absolute; overflow: hidden; left: 640px; top: 0px; width: 320px; height: 240px "><img id="blur_id_img2" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img2" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img3" style="position: absolute; overflow: hidden; left: 960px; top: 0px; width: 320px; height: 240px "><img id="blur_id_img3" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img3" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img4" style="position: absolute; overflow: hidden; left: 1280px; top: 0px; width: 320px; height: 240px "><img id="blur_id_img4" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img4" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img5" style="position: absolute; overflow: hidden; left: 1600px; top: 0px; width: 320px; height: 240px "><img id="blur_id_img5" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img5" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img6" style="position: absolute; overflow: hidden; left: 1920px; top: 0px; width: 320px; height: 240px "><img id="blur_id_img6" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img6" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img7" style="position: absolute; overflow: hidden; left: 2240px; top: 0px; width: 320px; height: 240px "><img id="blur_id_img7" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img7" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img8" style="position: absolute; overflow: hidden; left: 2560px; top: 0px; width: 320px; height: 240px "><img id="blur_id_img8" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img8" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img9" style="position: absolute; overflow: hidden; left: 0px; top: 240px; width: 320px; height: 240px "><img id="blur_id_img9" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img9" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img10" style="position: absolute; overflow: hidden; left: 320px; top: 240px; width: 320px; height: 240px "><img id="blur_id_img10" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img10" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img11" style="position: absolute; overflow: hidden; left: 640px; top: 240px; width: 320px; height: 240px "><img id="blur_id_img11" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img11" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img12" style="position: absolute; overflow: hidden; left: 960px; top: 240px; width: 320px; height: 240px "><img id="blur_id_img12" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img12" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img13" style="position: absolute; overflow: hidden; left: 1280px; top: 240px; width: 320px; height: 240px "><img id="blur_id_img13" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img13" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img14" style="position: absolute; overflow: hidden; left: 1600px; top: 240px; width: 320px; height: 240px "><img id="blur_id_img14" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img14" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img15" style="position: absolute; overflow: hidden; left: 1920px; top: 240px; width: 320px; height: 240px "><img id="blur_id_img15" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img15" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img16" style="position: absolute; overflow: hidden; left: 2240px; top: 240px; width: 320px; height: 240px "><img id="blur_id_img16" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img16" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img17" style="position: absolute; overflow: hidden; left: 2560px; top: 240px; width: 320px; height: 240px "><img id="blur_id_img17" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img17" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img18" style="position: absolute; overflow: hidden; left: 0px; top: 480px; width: 320px; height: 240px "><img id="blur_id_img18" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img18" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img19" style="position: absolute; overflow: hidden; left: 320px; top: 480px; width: 320px; height: 240px "><img id="blur_id_img19" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img19" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img20" style="position: absolute; overflow: hidden; left: 640px; top: 480px; width: 320px; height: 240px "><img id="blur_id_img20" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img20" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img21" style="position: absolute; overflow: hidden; left: 960px; top: 480px; width: 320px; height: 240px "><img id="blur_id_img21" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img21" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img22" style="position: absolute; overflow: hidden; left: 1280px; top: 480px; width: 320px; height: 240px "><img id="blur_id_img22" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img22" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img23" style="position: absolute; overflow: hidden; left: 1600px; top: 480px; width: 320px; height: 240px "><img id="blur_id_img23" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img23" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img24" style="position: absolute; overflow: hidden; left: 1920px; top: 480px; width: 320px; height: 240px "><img id="blur_id_img24" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img24" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img25" style="position: absolute; overflow: hidden; left: 2240px; top: 480px; width: 320px; height: 240px "><img id="blur_id_img25" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img25" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img26" style="position: absolute; overflow: hidden; left: 2560px; top: 480px; width: 320px; height: 240px "><img id="blur_id_img26" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img26" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img27" style="position: absolute; overflow: hidden; left: 0px; top: 720px; width: 320px; height: 240px "><img id="blur_id_img27" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img27" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img28" style="position: absolute; overflow: hidden; left: 320px; top: 720px; width: 320px; height: 240px "><img id="blur_id_img28" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img28" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img29" style="position: absolute; overflow: hidden; left: 640px; top: 720px; width: 320px; height: 240px "><img id="blur_id_img29" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img29" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img30" style="position: absolute; overflow: hidden; left: 960px; top: 720px; width: 320px; height: 240px "><img id="blur_id_img30" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img30" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img31" style="position: absolute; overflow: hidden; left: 1280px; top: 720px; width: 320px; height: 240px "><img id="blur_id_img31" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img31" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img32" style="position: absolute; overflow: hidden; left: 1600px; top: 720px; width: 320px; height: 240px "><img id="blur_id_img32" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img32" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img33" style="position: absolute; overflow: hidden; left: 1920px; top: 720px; width: 320px; height: 240px "><img id="blur_id_img33" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img33" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img34" style="position: absolute; overflow: hidden; left: 2240px; top: 720px; width: 320px; height: 240px "><img id="blur_id_img34" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img34" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img35" style="position: absolute; overflow: hidden; left: 2560px; top: 720px; width: 320px; height: 240px "><img id="blur_id_img35" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img35" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img36" style="position: absolute; overflow: hidden; left: 0px; top: 960px; width: 320px; height: 240px "><img id="blur_id_img36" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img36" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img37" style="position: absolute; overflow: hidden; left: 320px; top: 960px; width: 320px; height: 240px "><img id="blur_id_img37" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img37" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img38" style="position: absolute; overflow: hidden; left: 640px; top: 960px; width: 320px; height: 240px "><img id="blur_id_img38" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img38" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img39" style="position: absolute; overflow: hidden; left: 960px; top: 960px; width: 320px; height: 240px "><img id="blur_id_img39" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img39" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img40" style="position: absolute; overflow: hidden; left: 1280px; top: 960px; width: 320px; height: 240px "><img id="blur_id_img40" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img40" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img41" style="position: absolute; overflow: hidden; left: 1600px; top: 960px; width: 320px; height: 240px "><img id="blur_id_img41" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img41" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img42" style="position: absolute; overflow: hidden; left: 1920px; top: 960px; width: 320px; height: 240px "><img id="blur_id_img42" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img42" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img43" style="position: absolute; overflow: hidden; left: 2240px; top: 960px; width: 320px; height: 240px "><img id="blur_id_img43" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img43" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img44" style="position: absolute; overflow: hidden; left: 2560px; top: 960px; width: 320px; height: 240px "><img id="blur_id_img44" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img44" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img45" style="position: absolute; overflow: hidden; left: 0px; top: 1200px; width: 320px; height: 240px "><img id="blur_id_img45" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img45" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img46" style="position: absolute; overflow: hidden; left: 320px; top: 1200px; width: 320px; height: 240px "><img id="blur_id_img46" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img46" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img47" style="position: absolute; overflow: hidden; left: 640px; top: 1200px; width: 320px; height: 240px "><img id="blur_id_img47" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img47" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img48" style="position: absolute; overflow: hidden; left: 960px; top: 1200px; width: 320px; height: 240px "><img id="blur_id_img48" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img48" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img49" style="position: absolute; overflow: hidden; left: 1280px; top: 1200px; width: 320px; height: 240px "><img id="blur_id_img49" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img49" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img50" style="position: absolute; overflow: hidden; left: 1600px; top: 1200px; width: 320px; height: 240px "><img id="blur_id_img50" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img50" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img51" style="position: absolute; overflow: hidden; left: 1920px; top: 1200px; width: 320px; height: 240px "><img id="blur_id_img51" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img51" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img52" style="position: absolute; overflow: hidden; left: 2240px; top: 1200px; width: 320px; height: 240px "><img id="blur_id_img52" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img52" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img53" style="position: absolute; overflow: hidden; left: 2560px; top: 1200px; width: 320px; height: 240px "><img id="blur_id_img53" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img53" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img54" style="position: absolute; overflow: hidden; left: 0px; top: 1440px; width: 320px; height: 240px "><img id="blur_id_img54" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img54" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img55" style="position: absolute; overflow: hidden; left: 320px; top: 1440px; width: 320px; height: 240px "><img id="blur_id_img55" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img55" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img56" style="position: absolute; overflow: hidden; left: 640px; top: 1440px; width: 320px; height: 240px "><img id="blur_id_img56" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img56" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img57" style="position: absolute; overflow: hidden; left: 960px; top: 1440px; width: 320px; height: 240px "><img id="blur_id_img57" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img57" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img58" style="position: absolute; overflow: hidden; left: 1280px; top: 1440px; width: 320px; height: 240px "><img id="blur_id_img58" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img58" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img59" style="position: absolute; overflow: hidden; left: 1600px; top: 1440px; width: 320px; height: 240px "><img id="blur_id_img59" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img59" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img60" style="position: absolute; overflow: hidden; left: 1920px; top: 1440px; width: 320px; height: 240px "><img id="blur_id_img60" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img60" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img61" style="position: absolute; overflow: hidden; left: 2240px; top: 1440px; width: 320px; height: 240px "><img id="blur_id_img61" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img61" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img62" style="position: absolute; overflow: hidden; left: 2560px; top: 1440px; width: 320px; height: 240px "><img id="blur_id_img62" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img62" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img63" style="position: absolute; overflow: hidden; left: 0px; top: 1680px; width: 320px; height: 240px "><img id="blur_id_img63" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img63" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img64" style="position: absolute; overflow: hidden; left: 320px; top: 1680px; width: 320px; height: 240px "><img id="blur_id_img64" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img64" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img65" style="position: absolute; overflow: hidden; left: 640px; top: 1680px; width: 320px; height: 240px "><img id="blur_id_img65" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img65" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img66" style="position: absolute; overflow: hidden; left: 960px; top: 1680px; width: 320px; height: 240px "><img id="blur_id_img66" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img66" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img67" style="position: absolute; overflow: hidden; left: 1280px; top: 1680px; width: 320px; height: 240px "><img id="blur_id_img67" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img67" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img68" style="position: absolute; overflow: hidden; left: 1600px; top: 1680px; width: 320px; height: 240px "><img id="blur_id_img68" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img68" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img69" style="position: absolute; overflow: hidden; left: 1920px; top: 1680px; width: 320px; height: 240px "><img id="blur_id_img69" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img69" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img70" style="position: absolute; overflow: hidden; left: 2240px; top: 1680px; width: 320px; height: 240px "><img id="blur_id_img70" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img70" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img71" style="position: absolute; overflow: hidden; left: 2560px; top: 1680px; width: 320px; height: 240px "><img id="blur_id_img71" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img71" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img72" style="position: absolute; overflow: hidden; left: 0px; top: 1920px; width: 320px; height: 240px "><img id="blur_id_img72" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img72" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img73" style="position: absolute; overflow: hidden; left: 320px; top: 1920px; width: 320px; height: 240px "><img id="blur_id_img73" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img73" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img74" style="position: absolute; overflow: hidden; left: 640px; top: 1920px; width: 320px; height: 240px "><img id="blur_id_img74" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img74" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img75" style="position: absolute; overflow: hidden; left: 960px; top: 1920px; width: 320px; height: 240px "><img id="blur_id_img75" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img75" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img76" style="position: absolute; overflow: hidden; left: 1280px; top: 1920px; width: 320px; height: 240px "><img id="blur_id_img76" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img76" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img77" style="position: absolute; overflow: hidden; left: 1600px; top: 1920px; width: 320px; height: 240px "><img id="blur_id_img77" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img77" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img78" style="position: absolute; overflow: hidden; left: 1920px; top: 1920px; width: 320px; height: 240px "><img id="blur_id_img78" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img78" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img79" style="position: absolute; overflow: hidden; left: 2240px; top: 1920px; width: 320px; height: 240px "><img id="blur_id_img79" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img79" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div><div id="div_id_img80" style="position: absolute; overflow: hidden; left: 2560px; top: 1920px; width: 320px; height: 240px "><img id="blur_id_img80" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><img id="id_img80" src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/empty-transparent.png" border=0 style="z-index: 2; position: absolute; -moz-user-select: none; user-select: none; -khtml-user-select: none; left: 0px; top: 0px;" width="320" height="240" oncontextmenu="return false" galleryimg="no"><\/div> <\/div> <!-- mymap -->  <div id="MMMAP_scale" style="position:absolute;height:50px;width:550px;border:0px solid black;bottom: 0px; left: 10px;z-index:900"><\/div> <div id="MMMAP_notice" style="font-size: 7pt; font-family: tahoma, helvetica; position:absolute;height:17px;width:600px;border:0px solid black;bottom: 0px; left: 15px;z-index:900">Powered by <span style="text-decoration: underline;cursor: pointer" onclick="window.open(\'http:\/\/map.longdo.com\/\')">Longdo Map<\/span> &copy; <span style="text-decoration: underline;cursor: pointer" onclick="window.open(\'http:\/\/www.mm.co.th\')">MM<\/span> - Map data: &copy; <span style="text-decoration: underline;cursor: pointer" onclick="window.open(\'http:\/\/www.numap.co.th\')">NuMAP<\/span> - <span style="text-decoration: underline;cursor: pointer" onclick="window.open(\'http:\/\/map.longdo.com\/terms\')">Terms<\/span><\/div>  <\/div> <!-- maparea -->  <div id="span_current_resolution_text_div" style="position:absolute;z-index:1;font-size: 9pt; font-family: tahoma, helvetica"> 	<b>zoom:<\/b> <span id="span_current_resolution">0<\/span> <\/div>  <div id="resolution_bar_div" style="position:absolute;border: 0px solid black;z-index:3" onchange="mmmap.setRes(Math.pow(2,this.myObject.getValue()));" onmoved="mmmap.setDisplayRes(Math.pow(2,this.myObject.getValue()));"> <\/div>  <div id="zooming_image_div" style="position:absolute; z-index:900; left:0; top:0; visibility: hidden"><img src="http:\/\/mmmap15.longdo.com\/mmmap\/images\/zooming.gif" border=0><\/div>  <div id="MMMAP_modeselector" style="position:absolute;z-index:2;font-size: 9pt;top: 5px; font-family: tahoma, helvetica">  <SELECT id="modeselectorselect" onchange="mmmap.setMapMode(this.options[selectedIndex].value)" onclick="event.returnValue = false; event.cancelBubble = true; return false"> <OPTION value="icons">&nbsp;&nbsp;-- เลือกแผนที่ --<\/OPTION> <OPTION value=\'icons\'>สถานที่<\/OPTION> <OPTION value=\'icons-en\'>สถานที่ (EN)<\/OPTION> <OPTION value=\'icons-ja\'>สถานที่ (JA)<\/OPTION> <OPTION value=\'normal\'>ถนน<\/OPTION> <OPTION value=\'normal-en\'>ถนน (EN)<\/OPTION> <OPTION value=\'normal-ja\'>ถนน (JA)<\/OPTION> <OPTION value=\'gray+overlay\'>จราจร (NECTEC-ITS)<\/OPTION> <OPTION value=\'gray+overlay-en\'>จราจร (NECTEC-ITS) (EN)<\/OPTION> <OPTION value=\'gray+overlay-ja\'>จราจร (NECTEC-ITS) (JA)<\/OPTION> <OPTION value=\'dark+overlay\'>จราจรสีดำ (NECTEC-ITS)<\/OPTION> <OPTION value=\'rail\'>รถไฟ<\/OPTION> <OPTION value=\'rail-en\'>รถไฟ (EN)<\/OPTION> <OPTION value=\'political\'>เขตการปกครอง<\/OPTION> <OPTION value=\'political-en\'>เขตการปกครอง (EN)<\/OPTION> <OPTION value=\'gpp2007p1\'>GPP 2007p1<\/OPTION> <OPTION value=\'gpp2007p1_capita\'>GPP 2007p1 per Capita<\/OPTION> <OPTION value=\'gpp2007p1_population\'>ประชากร (2550)<\/OPTION> <OPTION value=\'gray\'>สีเทา<\/OPTION> <OPTION value=\'gray-en\'>สีเทา (EN)<\/OPTION> <OPTION value=\'gray-ja\'>สีเทา (JA)<\/OPTION> <OPTION value=\'water\'>ทางน้ำ<\/OPTION> <OPTION value=\'minimal\'>โล่งๆ<\/OPTION> <OPTION value=\'dark\'>สีดำ<\/OPTION> <OPTION value=\'hydro\'>พื้นฐาน<\/OPTION> <\/SELECT> <\/div>  <div id="json_scrdiv"><\/div>  ';

    degree_to_pixel = (imagewidth * resolution) / longitude_range;

    mymap = document.getElementById("id_mymap");

    mymaparea = document.getElementById("maparea");
    this.maparea = document.getElementById("maparea");

    center_point = document.getElementById("MMMAP_center_point");

    this.editing_div = document.getElementById("_mmmap_editing_div");

    tt = document.getElementById("_mmmap_texttip");
    tt.onmouseover = function() { mmmap.cancelhidetexttip(); };
    tt.onmouseout = function() { this.timer = setTimeout("document.getElementById('_mmmap_texttip').style.display = 'none'", this.defaultdelay); };

    // init images
    images[0] = document.getElementById('id_img0'); poi_images_num[0] = 0; poi_images[0] = new Array(); poi_images_label[0] = new Array();
    images[1] = document.getElementById('id_img1'); poi_images_num[1] = 0; poi_images[1] = new Array(); poi_images_label[1] = new Array();
    images[2] = document.getElementById('id_img2'); poi_images_num[2] = 0; poi_images[2] = new Array(); poi_images_label[2] = new Array();
    images[3] = document.getElementById('id_img3'); poi_images_num[3] = 0; poi_images[3] = new Array(); poi_images_label[3] = new Array();
    images[4] = document.getElementById('id_img4'); poi_images_num[4] = 0; poi_images[4] = new Array(); poi_images_label[4] = new Array();
    images[5] = document.getElementById('id_img5'); poi_images_num[5] = 0; poi_images[5] = new Array(); poi_images_label[5] = new Array();
    images[6] = document.getElementById('id_img6'); poi_images_num[6] = 0; poi_images[6] = new Array(); poi_images_label[6] = new Array();
    images[7] = document.getElementById('id_img7'); poi_images_num[7] = 0; poi_images[7] = new Array(); poi_images_label[7] = new Array();
    images[8] = document.getElementById('id_img8'); poi_images_num[8] = 0; poi_images[8] = new Array(); poi_images_label[8] = new Array();
    images[9] = document.getElementById('id_img9'); poi_images_num[9] = 0; poi_images[9] = new Array(); poi_images_label[9] = new Array();
    images[10] = document.getElementById('id_img10'); poi_images_num[10] = 0; poi_images[10] = new Array(); poi_images_label[10] = new Array();
    images[11] = document.getElementById('id_img11'); poi_images_num[11] = 0; poi_images[11] = new Array(); poi_images_label[11] = new Array();
    images[12] = document.getElementById('id_img12'); poi_images_num[12] = 0; poi_images[12] = new Array(); poi_images_label[12] = new Array();
    images[13] = document.getElementById('id_img13'); poi_images_num[13] = 0; poi_images[13] = new Array(); poi_images_label[13] = new Array();
    images[14] = document.getElementById('id_img14'); poi_images_num[14] = 0; poi_images[14] = new Array(); poi_images_label[14] = new Array();
    images[15] = document.getElementById('id_img15'); poi_images_num[15] = 0; poi_images[15] = new Array(); poi_images_label[15] = new Array();
    images[16] = document.getElementById('id_img16'); poi_images_num[16] = 0; poi_images[16] = new Array(); poi_images_label[16] = new Array();
    images[17] = document.getElementById('id_img17'); poi_images_num[17] = 0; poi_images[17] = new Array(); poi_images_label[17] = new Array();
    images[18] = document.getElementById('id_img18'); poi_images_num[18] = 0; poi_images[18] = new Array(); poi_images_label[18] = new Array();
    images[19] = document.getElementById('id_img19'); poi_images_num[19] = 0; poi_images[19] = new Array(); poi_images_label[19] = new Array();
    images[20] = document.getElementById('id_img20'); poi_images_num[20] = 0; poi_images[20] = new Array(); poi_images_label[20] = new Array();
    images[21] = document.getElementById('id_img21'); poi_images_num[21] = 0; poi_images[21] = new Array(); poi_images_label[21] = new Array();
    images[22] = document.getElementById('id_img22'); poi_images_num[22] = 0; poi_images[22] = new Array(); poi_images_label[22] = new Array();
    images[23] = document.getElementById('id_img23'); poi_images_num[23] = 0; poi_images[23] = new Array(); poi_images_label[23] = new Array();
    images[24] = document.getElementById('id_img24'); poi_images_num[24] = 0; poi_images[24] = new Array(); poi_images_label[24] = new Array();
    images[25] = document.getElementById('id_img25'); poi_images_num[25] = 0; poi_images[25] = new Array(); poi_images_label[25] = new Array();
    images[26] = document.getElementById('id_img26'); poi_images_num[26] = 0; poi_images[26] = new Array(); poi_images_label[26] = new Array();
    images[27] = document.getElementById('id_img27'); poi_images_num[27] = 0; poi_images[27] = new Array(); poi_images_label[27] = new Array();
    images[28] = document.getElementById('id_img28'); poi_images_num[28] = 0; poi_images[28] = new Array(); poi_images_label[28] = new Array();
    images[29] = document.getElementById('id_img29'); poi_images_num[29] = 0; poi_images[29] = new Array(); poi_images_label[29] = new Array();
    images[30] = document.getElementById('id_img30'); poi_images_num[30] = 0; poi_images[30] = new Array(); poi_images_label[30] = new Array();
    images[31] = document.getElementById('id_img31'); poi_images_num[31] = 0; poi_images[31] = new Array(); poi_images_label[31] = new Array();
    images[32] = document.getElementById('id_img32'); poi_images_num[32] = 0; poi_images[32] = new Array(); poi_images_label[32] = new Array();
    images[33] = document.getElementById('id_img33'); poi_images_num[33] = 0; poi_images[33] = new Array(); poi_images_label[33] = new Array();
    images[34] = document.getElementById('id_img34'); poi_images_num[34] = 0; poi_images[34] = new Array(); poi_images_label[34] = new Array();
    images[35] = document.getElementById('id_img35'); poi_images_num[35] = 0; poi_images[35] = new Array(); poi_images_label[35] = new Array();
    images[36] = document.getElementById('id_img36'); poi_images_num[36] = 0; poi_images[36] = new Array(); poi_images_label[36] = new Array();
    images[37] = document.getElementById('id_img37'); poi_images_num[37] = 0; poi_images[37] = new Array(); poi_images_label[37] = new Array();
    images[38] = document.getElementById('id_img38'); poi_images_num[38] = 0; poi_images[38] = new Array(); poi_images_label[38] = new Array();
    images[39] = document.getElementById('id_img39'); poi_images_num[39] = 0; poi_images[39] = new Array(); poi_images_label[39] = new Array();
    images[40] = document.getElementById('id_img40'); poi_images_num[40] = 0; poi_images[40] = new Array(); poi_images_label[40] = new Array();
    images[41] = document.getElementById('id_img41'); poi_images_num[41] = 0; poi_images[41] = new Array(); poi_images_label[41] = new Array();
    images[42] = document.getElementById('id_img42'); poi_images_num[42] = 0; poi_images[42] = new Array(); poi_images_label[42] = new Array();
    images[43] = document.getElementById('id_img43'); poi_images_num[43] = 0; poi_images[43] = new Array(); poi_images_label[43] = new Array();
    images[44] = document.getElementById('id_img44'); poi_images_num[44] = 0; poi_images[44] = new Array(); poi_images_label[44] = new Array();
    images[45] = document.getElementById('id_img45'); poi_images_num[45] = 0; poi_images[45] = new Array(); poi_images_label[45] = new Array();
    images[46] = document.getElementById('id_img46'); poi_images_num[46] = 0; poi_images[46] = new Array(); poi_images_label[46] = new Array();
    images[47] = document.getElementById('id_img47'); poi_images_num[47] = 0; poi_images[47] = new Array(); poi_images_label[47] = new Array();
    images[48] = document.getElementById('id_img48'); poi_images_num[48] = 0; poi_images[48] = new Array(); poi_images_label[48] = new Array();
    images[49] = document.getElementById('id_img49'); poi_images_num[49] = 0; poi_images[49] = new Array(); poi_images_label[49] = new Array();
    images[50] = document.getElementById('id_img50'); poi_images_num[50] = 0; poi_images[50] = new Array(); poi_images_label[50] = new Array();
    images[51] = document.getElementById('id_img51'); poi_images_num[51] = 0; poi_images[51] = new Array(); poi_images_label[51] = new Array();
    images[52] = document.getElementById('id_img52'); poi_images_num[52] = 0; poi_images[52] = new Array(); poi_images_label[52] = new Array();
    images[53] = document.getElementById('id_img53'); poi_images_num[53] = 0; poi_images[53] = new Array(); poi_images_label[53] = new Array();
    images[54] = document.getElementById('id_img54'); poi_images_num[54] = 0; poi_images[54] = new Array(); poi_images_label[54] = new Array();
    images[55] = document.getElementById('id_img55'); poi_images_num[55] = 0; poi_images[55] = new Array(); poi_images_label[55] = new Array();
    images[56] = document.getElementById('id_img56'); poi_images_num[56] = 0; poi_images[56] = new Array(); poi_images_label[56] = new Array();
    images[57] = document.getElementById('id_img57'); poi_images_num[57] = 0; poi_images[57] = new Array(); poi_images_label[57] = new Array();
    images[58] = document.getElementById('id_img58'); poi_images_num[58] = 0; poi_images[58] = new Array(); poi_images_label[58] = new Array();
    images[59] = document.getElementById('id_img59'); poi_images_num[59] = 0; poi_images[59] = new Array(); poi_images_label[59] = new Array();
    images[60] = document.getElementById('id_img60'); poi_images_num[60] = 0; poi_images[60] = new Array(); poi_images_label[60] = new Array();
    images[61] = document.getElementById('id_img61'); poi_images_num[61] = 0; poi_images[61] = new Array(); poi_images_label[61] = new Array();
    images[62] = document.getElementById('id_img62'); poi_images_num[62] = 0; poi_images[62] = new Array(); poi_images_label[62] = new Array();
    images[63] = document.getElementById('id_img63'); poi_images_num[63] = 0; poi_images[63] = new Array(); poi_images_label[63] = new Array();
    images[64] = document.getElementById('id_img64'); poi_images_num[64] = 0; poi_images[64] = new Array(); poi_images_label[64] = new Array();
    images[65] = document.getElementById('id_img65'); poi_images_num[65] = 0; poi_images[65] = new Array(); poi_images_label[65] = new Array();
    images[66] = document.getElementById('id_img66'); poi_images_num[66] = 0; poi_images[66] = new Array(); poi_images_label[66] = new Array();
    images[67] = document.getElementById('id_img67'); poi_images_num[67] = 0; poi_images[67] = new Array(); poi_images_label[67] = new Array();
    images[68] = document.getElementById('id_img68'); poi_images_num[68] = 0; poi_images[68] = new Array(); poi_images_label[68] = new Array();
    images[69] = document.getElementById('id_img69'); poi_images_num[69] = 0; poi_images[69] = new Array(); poi_images_label[69] = new Array();
    images[70] = document.getElementById('id_img70'); poi_images_num[70] = 0; poi_images[70] = new Array(); poi_images_label[70] = new Array();
    images[71] = document.getElementById('id_img71'); poi_images_num[71] = 0; poi_images[71] = new Array(); poi_images_label[71] = new Array();
    images[72] = document.getElementById('id_img72'); poi_images_num[72] = 0; poi_images[72] = new Array(); poi_images_label[72] = new Array();
    images[73] = document.getElementById('id_img73'); poi_images_num[73] = 0; poi_images[73] = new Array(); poi_images_label[73] = new Array();
    images[74] = document.getElementById('id_img74'); poi_images_num[74] = 0; poi_images[74] = new Array(); poi_images_label[74] = new Array();
    images[75] = document.getElementById('id_img75'); poi_images_num[75] = 0; poi_images[75] = new Array(); poi_images_label[75] = new Array();
    images[76] = document.getElementById('id_img76'); poi_images_num[76] = 0; poi_images[76] = new Array(); poi_images_label[76] = new Array();
    images[77] = document.getElementById('id_img77'); poi_images_num[77] = 0; poi_images[77] = new Array(); poi_images_label[77] = new Array();
    images[78] = document.getElementById('id_img78'); poi_images_num[78] = 0; poi_images[78] = new Array(); poi_images_label[78] = new Array();
    images[79] = document.getElementById('id_img79'); poi_images_num[79] = 0; poi_images[79] = new Array(); poi_images_label[79] = new Array();
    images[80] = document.getElementById('id_img80'); poi_images_num[80] = 0; poi_images[80] = new Array(); poi_images_label[80] = new Array();

    var barwidth = resolution_steps * 20;
    slider1 = new Slider(document.getElementById('resolution_bar_div'), barwidth, 20, Math.log(min_resolution) / Math.log(2), Math.log(max_resolution) / Math.log(2));
    slider1.setValue(Math.log(resolution) / Math.log(2));

    jg = new jsGraphics("MMMAP_scale");


    var kmPerLon = 111.321;
    var kmPerLat = 111;

    isDown = false;

    //showingmark = -1; // if the marks are being shown or not, normal value is true or false
    showingmark = true; // lets show it as default

    this.mapdiv.oncontextmenu = function(e) {
        if (e) event = e;
        event.cancelBubble = true;
        event.returnValue = false;
        return false;
    };

    this.ooi_constraints = new Array();
    this.ooi_constraints_showlevel_min = new Array();
    this.ooi_constraints_showlevel_max = new Array();
    this.ooi_constraints_showlevel_label_min = new Array();
    this.ooi_constraints_showlevel_label_max = new Array();
    this.ooi_constraints_iconmode = new Array();

    this.clearAllOOITags = function() {
        this.ooi_constraints = new Array();
        this.ooi_constraints_showlevel_min = new Array();
        this.ooi_constraints_showlevel_max = new Array();
        this.ooi_constraints_showlevel_label_min = new Array();
        this.ooi_constraints_showlevel_label_max = new Array();
        this.ooi_constraints_iconmode = new Array();

        this.showpoi = 100000;

        this.setAllImagesUsedButNotSetToEmpty();
        this.rePaint();
    }

    this.showOOITag = function(_tag) {
        this.showOOITagWithShowLevel(_tag, 0, 0, 0, 0);
    }

    // these showlevel_*, 0 means default from DB
    this.showOOITagWithShowLevel = function(_tag, showlevel_min, showlevel_max, showlevel_label_min, showlevel_label_max) {
        this.showOOITagWithShowLevelWithCustomIcon(_tag, showlevel_min, showlevel_max, showlevel_label_min, showlevel_label_max, "");
    }

    // iconmode = "" means default (server-supplied), "none" means no icon, otherwise an image location (URL) of custom icon
    this.showOOITagWithShowLevelWithCustomIcon = function(_tag, showlevel_min, showlevel_max, showlevel_label_min, showlevel_label_max, iconmode) {
        if (this.ooi_constraints) {
            var found = false;
            for (var i = 0; i < this.ooi_constraints.length; i++) {
                if (this.ooi_constraints[i] == "_tag") {
                    found = true;
                }
            }

            var idx;
            if (!found) {
                idx = this.ooi_constraints.length;
                this.ooi_constraints[idx] = _tag;
            }
            this.ooi_constraints_showlevel_min[idx] = showlevel_min;
            this.ooi_constraints_showlevel_max[idx] = showlevel_max;

            this.ooi_constraints_showlevel_label_min[idx] = showlevel_label_min;
            this.ooi_constraints_showlevel_label_max[idx] = showlevel_label_max;

            this.ooi_constraints_iconmode[idx] = iconmode;

            this.initPOIArrays();

            if (showlevel_min < this.showpoi) {
                this.showpoi = showlevel_min;
            }

            this.setAllImagesUsedButNotSetToEmpty();
            this.rePaint();
        }
    }

    this.getKmPerLat = function() {
        return kmPerLat;
    }

    this.getKmPerLong = function(_lat) {
        // FIXME this is an approximate value, actualy need to take _lat into account
        return kmPerLon;
    }

    this.setRememberLastPosition = function() {
        addEvent(window, "unload", this.setPositionCookie);
    }

    this.setPositionCookie = function() {
        createCookie("cookie_lat", latitude, 0);
        createCookie("cookie_long", longitude, 0);
        createCookie("cookie_res", resolution, 0);
    }

    updatevector_lock = false;
    this.updatevectoronreq = function() { };
    this.updatevectoronsucc = function() { };

    this.initVector = function() {
        this.__setVectorDivPos();

        this.mapvector_currentzoom = -1;
        this.gsfgcolor = "#FF0000";
        this.gslinewidth = "1";
        this.gsopacity = "0.6";
        this.gsfillcolor = ""; //--------- color in shape
        this.vectorvisible = true;
        this.vectorhided = false;
        this.vectorhilightenable = true;
        this.vectorhilightmethod = "lighter"; // lighter, darker, color
        this.vectorhilightcolor = "#FFAAAA";
        this.vectorhilightdiffamount = 40;
        this.vectorhilightwidthfactor = 2;
        this.updatevectortimer = false;

        // polyline handler
        //this.gsmouseover = "";
        this.gseventshandler = "";
        this.lineobject = "";
    }

    this.__setVectorDivPos = function() {
        uv_v = document.getElementById("_mmmap_vector_div");
        uv_v.style.left = 0;
        uv_v.style.top = 0;
        uv_v.style.width = longitude_range * degree_to_pixel;
        uv_v.style.height = (maxlatitude - minlatitude) * degree_to_pixel;

        this.vectorsize_w = longitude_range * degree_to_pixel;
        this.vectorsize_h = (maxlatitude - minlatitude) * degree_to_pixel;
    }

    this.getMapDiv = function() {
        return this.mapdiv;
    };

    this.initPOIArrays = function() {
        for (var i = min_zoom; i <= max_zoom; i++) { // looping through resolutions
            poi_num[i] = new Array();
            poi_saved[i] = new Array();
        }
    }

    this.showMap = function() {
        if (this.mmruler) {
            this.mmruler.setVisibility(true);
        }

        this.mapdiv.style.visibility = "visible";
        this.rePaint();
    }

    this.hideMap = function() {
        if (this.mmruler) {
            this.mmruler.setVisibility(false);
        }

        this.mapdiv.style.visibility = "hidden";
        this.hideCenterMark();
    }

    this.getMapMode = function() {
        return this.mapmode;
    }

    this._setMapMode = function(_mode) {
        this.mapmode = _mode;
    }

    this._refreshoverlaytimer = null;
    this._refreshoverlayinterval = 0;
    this.loopRefreshOverlay = function() {
        if (this._refreshoverlayinterval > 0) {
            this.refreshLayers();
            this._refreshoverlaytimer = setTimeout("mmmap.loopRefreshOverlay()", this._refreshoverlayinterval);
        }
    }

    // set to 0 to stop refreshing
    this.setRefreshOverlayInterval = function(interval) {
        if (interval == 0) {
            if (this._refreshoverlaytimer) clearTimeout(this._refreshoverlaytimer);
        }
        this._refreshoverlayinterval = interval * 1000;
    }

    this.showLayersControl = function() {
        if (typeof (this.LayersControl.control) == 'undefined' || this.LayersControl.updatelayer) {
            if (this.createLayersControl) this.createLayersControl();
        }
        this.LayersControl.attributes.display = 'block';
        this.LayersControl.control.style.display = this.LayersControl.attributes.display;
    };

    this.hideLayersControl = function() {
        this.LayersControl.attributes.display = 'none';
        this.LayersControl.control.style.display = this.LayersControl.attributes.display;
    }

    this.updateLayersControl = function(layername, val) {
        var cid = 'mm-layer-' + layername;
        if (document.getElementById(cid)) document.getElementById(cid).checked = val;
    }

    this.setLayersControlAttributes = function(attar) {
    };

    this.refreshLayers = function() {
        if (this.__layers.length <= 0) return;
        var d = new Date();
        var timestamp = parseInt(d.getTime() / 60000);
        for (var i = 0; i < this.__layers.length; i++) {
            for (var j = 0; j < numimages * numimages; j++) {
                if (this.__layers[i].status == "active") {
                    if (this.__layers[i].startzoom <= this.getZoom() && this.__layers[i].stopzoom >= this.getZoom()) {
                        if (this.ovl_images[i][j].tmpsrc) {
                            if (this.__layers[i].nocache && this.__layers[i].nocache != 0) {
                                this.ovl_images[i][j].src = this.ovl_images[i][j].tmpsrc + "&rnd=" + timestamp;
                            } else {
                                this.ovl_images[i][j].src = this.ovl_images[i][j].tmpsrc;
                            }
                            this.ovl_images[i][j].style.visibility = "visible";
                        }
                    } else {
                        this.ovl_images[i][j].style.visibility = "hidden";
                    }
                } else {
                    this.ovl_images[i][j].style.visibility = "hidden";
                }
            }
        }
    }

    this.__layers = new Array();
    this.addLayer = function(attr) {
        if (attr && attr.layertype) {
            this.ovl_enable = true;
            var i = this.__layers.length;
            for (var j = 0; j < this.__layers.length; j++) {
                if (this.__layers[j].name == attr.name) {
                    i = j;
                    break;
                }
            }
            this.__layers[i] = attr;
            this.__layers[i].status = "active";
            this.__layers[i].startzoom = attr.startzoom ? attr.startzoom : min_zoom;
            this.__layers[i].stopzoom = attr.stopzoom ? attr.stopzoom : max_zoom;

            if (!this.ovl_images[i]) {
                this.ovl_images[i] = new Array();
                for (var j = 0; j < numimages; j++) {
                    for (var k = 0; k < numimages; k++) {
                        var imgid = j * numimages + k;
                        this.ovl_images[i][imgid] = document.createElement('img');
                        this.ovl_images[i][imgid].id = 'id_img_ovl_' + i + "_" + imgid;
                        this.ovl_images[i][imgid].src = "http://mmmap15.longdo.com//mmmap/images/empty-transparent.png";
                        this.ovl_images[i][imgid].style.position = "absolute";
                        this.ovl_images[i][imgid].style.left = "0px";
                        this.ovl_images[i][imgid].style.top = "0px";
                        var imageObject_div = document.getElementById("div_" + images[imgid].id);
                        imageObject_div.appendChild(this.ovl_images[i][imgid]);
                    }
                }
            }
            this.setAllImagesUsedButNotSetToEmpty();
            this.refreshLayers();
            this.showCenterAt(centerpos);
        }

        if (this.createLayersControl) this.createLayersControl();
    }

    this.deleteLayer = function(layername) {
        if (layername.name) { layername = layername.name };
        var stillsomelayer = false;
        for (var i = 0; i < this.__layers.length; i++) {
            if (this.__layers[i].name == layername) {
                if (this.__layers[i].status != "deleted") {
                    this.__layers[i].status = "deleted";
                    for (var j = 0; j < numimages; j++) {
                        for (var k = 0; k < numimages; k++) {
                            var imgid = j * numimages + k;
                            var imageObject_div = document.getElementById("div_" + images[imgid].id);
                            imageObject_div.removeChild(this.ovl_images[i][imgid]);
                        }
                    }
                }
            } else if (this.__layers[i].status == "active") {
                stillsomelayer = true;
            }
        }
        this.setAllOverlayImagesUsed();
        this.refreshLayers();
        this.showCenterAt(centerpos);

        if (!stillsomelayer) {
            this.ovl_enable = false;
        }

        if (this.createLayersControl) this.createLayersControl();
    }

    this.hideLayer = function(layername) {
        if (layername.name) { layername = layername.name };
        for (var i = 0; i < this.__layers.length; i++) {
            if (this.__layers[i].name == layername) {
                this.__layers[i].status = "inactive";
                break;
            }
        }
        this.setAllOverlayImagesUsed();
        this.setAllImagesUsedButNotSetToEmpty(); // FIXME shouldnt really have to do this -- just bad fix for usedAs doesn't handle layers
        this.refreshLayers();
        this.showCenterAt(centerpos);
        this.updateLayersControl(layername, false);
    }

    this.showLayer = function(layername) {
        if (layername.name) { layername = layername.name };
        for (var i = 0; i < this.__layers.length; i++) {
            if (this.__layers[i].name == layername) {
                this.__layers[i].status = "active";
                break;
            }
        }
        this.refreshLayers();
        this.updateLayersControl(layername, true)
    }

    this.deleteAllLayers = function() {
        this.__layers = new Array();
        this.refreshLayers();
    }

    this.setMapAttributes = function(attr) {
        if (attr && attr.opacity) {
            for (var i = 0; i < numimages * numimages; i++) {
                images[i].style.opacity = attr.opacity;
                images[i].style.filter = "alpha(opacity=" + parseInt(attr.opacity * 100) + ")";
            }
        }
    }

    this.__autoaddtrafficlayer = false;
    this.thailand_traffic = {
        layertype: "LONGDO",
        name: "thailand_traffic",
        url: "http://ms22.longdo.com/mmmap/img.php",
        mode: 'trafficoverlay',
        zIndex: 3,
        nocache: 1,
        startzoom: 4,
        stopzoom: 12
    };

    this.setMapMode = function(_mode) {
        var _mode_org = _mode;
        if (_mode == "traffic+overlay" || _mode == "traffic+overlay-en" || _mode == "traffic+overlay-ja"
						|| _mode == "gray+overlay" || _mode == "gray+overlay-en" || _mode == "gray+overlay-ja"
						|| _mode == "dark+overlay" || _mode == "dark+overlay-en"
					 ) {
            _mode = _mode.replace("+overlay", "");

            this.addLayer(this.thailand_traffic);
            this.__autoaddtrafficlayer = true;

            this.setRefreshOverlayInterval(180);
            this.loopRefreshOverlay();

        } else {
            if (this.__autoaddtrafficlayer && this.ovl_enable) {
                this.__autoaddtrafficlayer = false;
                mmmap.hideLayer("thailand_traffic");
                mmmap.refreshLayers();
                mmmap.setRefreshOverlayInterval(0);
            }
        }

        if (_mode == "dark" || _mode == "dark-en") {
            document.getElementById('span_current_resolution_text_div').style.color = "gray";
            document.getElementById('MMMAP_notice').style.color = "gray";
            document.getElementById('MMMAP_scale').style.color = "gray";
        } else {
            document.getElementById('span_current_resolution_text_div').style.color = "black";
            document.getElementById('MMMAP_notice').style.color = "black";
            document.getElementById('MMMAP_scale').style.color = "black";
        }
        this._setMapMode(_mode);
        var selector = document.getElementById('modeselectorselect');
        var i;
        for (i = 0; i < selector.options.length; i++) {
            if (selector.options[i].value == _mode_org) {
                selector.selectedIndex = i;
                break;
            }
        }

        this.setAllImagesUsedButNotSetToEmpty();
        this.rePaint();
    }

    this.enableMouseWheel = function() {
        //acceptWheel(mymaparea,do_scroll);
        acceptWheel(this.getMapDiv(), do_scroll);
        acceptWheel(document.getElementById("zooming_image_div"), do_scroll);
        acceptWheel(document.getElementById("MMMAP_center_point"), do_scroll);
    }

    this.disableMouseWheel = function() {
        //muteWheel(mymaparea,do_scroll); // until we process everything
        muteWheel(this.getMapDiv(), do_scroll); // until we process everything
        muteWheel(document.getElementById("zooming_image_div"), do_scroll); // until we process everything
        muteWheel(document.getElementById("MMMAP_center_point"), do_scroll); // until we process everything
    }

    _mmmap_div.posX = 0;
    _mmmap_div.posY = 0;

    this.numtiles = 3; // default

    this.setSize = function(newwidth, newheight) {
        if (!newwidth || !newheight) {
            return;
        }
        if (newwidth < 0) {
            newwidth = 0;
        }
        if (newheight < 0) {
            newheight = 0;
        }
        this.mapdiv.style.width = newwidth + "px";
        this.mapdiv.style.height = newheight + "px";

        mymaparea.style.width = newwidth + "px";
        mymaparea.style.height = newheight + "px";

        // for the sake of old-code as well as for my own usage
        mymaparea.width = newwidth;
        mymaparea.height = newheight;

        mymaparea.style.clip = "rect(0 " + mymaparea.style.width + " " + mymaparea.style.height + " 0)";

        var newpos = findObjPos(_mmmap_div);
        var offset = findBodyOffset();
        _mmmap_div.posX = newpos[0] - offset.offsetx;
        _mmmap_div.posY = newpos[1] - offset.offsety;

        var numtiles_width = Math.ceil(newwidth / imagewidth) + 1;
        if (parseInt(numtiles_width / 2) * 2 == numtiles_width)
            numtiles_width++;

        var numtiles_height = Math.ceil(newheight / imageheight) + 1;
        if (parseInt(numtiles_height / 2) * 2 == numtiles_height)
            numtiles_height++;

        this.numtiles = (numtiles_width > numtiles_height) ? numtiles_width : numtiles_height;
        if (this.numtiles > numimages) this.numtiles = numimages;
        if (this.numtiles < 3) this.numtiles = 3;
    };

    this.setCenter = function(_latitude, _longitude, _resolution) {
        resolution = _resolution;
        latitude = _latitude;
        longitude = _longitude;

        this.moveTo(latitude, longitude);

        this.setRes(resolution); // zoom to the new position
    };

    this.setCenterByImage = function(_centerpos) {
        current_center_x = (_centerpos % resolution) * imagewidth;
        current_center_y = parseInt((_centerpos / resolution) * imageheight); // floating point problem

        longitude = minlongitude + current_center_x / degree_to_pixel;
        latitude = maxlatitude - current_center_y / degree_to_pixel;

        this.showCenterAt(_centerpos);
        this.moveToCurrent();
    }

    this.setCenterByTG = function(_tg_x, _tg_y) {
        // Thai Geocode XXXXX-YYYYY
        // XXXXX = 100,000 * (latitude - 5 )
        // YYYYY = 100,000 * (longitude - 97 )

        var mylat = tgbase32todec(_tg_y) / 100000 + 5;
        var mylong = tgbase32todec(_tg_x) / 100000 + 97;
        this.moveTo(mylat, mylong);
    }

    this.getLatLngInTG = function(_lat, _long) {
        // Thai Geocode XXXXX-YYYYY
        // XXXXX = 100,000 * (latitude - 5 )
        // YYYYY = 100,000 * (longitude - 97 )

        var tgy = tgdectobase32(100000 * (_lat - 5));
        var tgx = tgdectobase32(100000 * (_long - 97));

        return tgx + "-" + tgy;
    }

    this.mouseCursorLat = function() {
        return maxlatitude - (myY - findPosY(mymap) + this.mapoffset.y) / degree_to_pixel;
    };

    this.mouseCursorLong = function() {
        return minlongitude + (myX - findPosX(mymap) + this.mapoffset.x) / degree_to_pixel;
    };

    this.centerLat = function() {
        return maxlatitude - (-findPosY(mymap) + mymaparea.height / 2 + this.mapoffset.y) / degree_to_pixel;
    };

    this.centerLong = function() {
        return minlongitude + (-findPosX(mymap) + mymaparea.width / 2 + this.mapoffset.x) / degree_to_pixel;
    };

    this.updateMouseCursorLocation = function() {
        var posX = findPosX(mymap);
        var posY = findPosY(mymap);

        mouse_cursor_x = myX - posX;
        mouse_cursor_y = myY - posY;
    };

    this._oldClientX = 0;
    this._oldClientY = 0;

    this.do_md = function do_md(e) {
        if (!e) e = window.event;

        clearPopup();

        var posX = findPosX(mymap);
        var posY = findPosY(mymap);

        var newpos = findObjPos(_mmmap_div);
        var offset = findBodyOffset();
        _mmmap_div.posX = newpos[0] - offset.offsetx;
        _mmmap_div.posY = newpos[1] - offset.offsety;

        myX = e.clientX - _mmmap_div.posX;
        myY = e.clientY - _mmmap_div.posY;

        this._oldClientX = e.clientX;
        this._oldClientY = e.clientY;

        mouse_cursor_x = myX - posX;
        mouse_cursor_y = myY - posY;

        var rightclick;
        if (e.which) {
            rightclick = (e.which == 3);
        } else if (e.button) {
            rightclick = (e.button == 2);
        }

        if (rightclick) {
            // show context menu
            mmmap.hidetexttipdelay(0);
            return do_rightclick();
        }

        // left click

        // check area, north hemisphere specific
        if (pointToLong(mouse_cursor_x, resolution) > maxlongitude || pointToLat(mouse_cursor_y, resolution) < minlatitude) {
            return;
        }

        mymap.style.cursor = "move";

        addX = posX - myX;
        addY = posY - myY;
        isDown = true;
        isDownAndMoved = false;

        if (mmmap.mouseDownHandler) mmmap.mouseDownHandler();

        if (browser != "Netscape")
            event.returnValue = false; // Cancel default behavior
        return false;
    };

    this.do_move = function do_move(e) {
        e = e ? e : window.event;

        if (this._oldClientX == e.clientX && this._oldClientY == e.clientY) {
            e.returnValue = false;
            e.cancelBubble = true;
            return false;
        }

        this._oldClientX = e.clientX;
        this._oldClientY = e.clientY;

        var newpos = findObjPos(_mmmap_div);
        var offset = findBodyOffset();
        _mmmap_div.posX = newpos[0] - offset.offsetx;
        _mmmap_div.posY = newpos[1] - offset.offsety;

        myX = e.clientX - _mmmap_div.posX;
        myY = e.clientY - _mmmap_div.posY;
        e.returnValue = false; // Cancel default behavior

        if (isDown) {
            isDownAndMoved = true;

            mouse_cursor_x = myX - findPosX(mymap);
            mouse_cursor_y = myY - findPosY(mymap);

            //window.status = "Mouse moving at pixel("+mouse_cursor_x+","+mouse_cursor_y+"), gps("+mmmap.mouseCursorLong()+", "+mmmap.mouseCursorLat()+")";
            //window.status += ": "+addX+","+addY;

            mymap.style.left = (addX + myX) + "px";
            mymap.style.top = (addY + myY) + "px";

            var currentx = -findPosX(mymap);
            var currenty = -findPosY(mymap);

            current_center_x = currentx + mymaparea.width / 2;
            current_center_y = currenty + mymaparea.height / 2;

            clearTimeout(this.last_domove_timer);
            this.last_domove_timer = setTimeout('mmmap._updateVisibles();mmmap.redrawCustomDivs();if (mmmap.mouseMoveHandler) mmmap.mouseMoveHandler();', 100)
            if (mmmap.mouseMoveHandlerNoDelay) mmmap.mouseMoveHandlerNoDelay();
        }
    };

    this.mouseWheelHandler = null;
    this.setMouseWheelHandler = function(f) {
        this.mouseWheelHandler = f;
    }

    this.mouseMoveHandler = null;
    this.setMouseMoveHandler = function(f) {
        this.mouseMoveHandler = f;
    }

    this.mouseMoveHandlerNoDelay = null;
    this.setMouseMoveHandlerNoDelay = function(f) {
        this.mouseMoveHandlerNoDelay = f;
    }

    this.mouseDownHandler = null;
    this.setMouseDownHandler = function(f) {
        this.mouseDownHandler = f;
    }

    this.mouseUpHandler = null;
    this.setMouseUpHandler = function(f) {
        this.mouseUpHandler = f;
    }

    this.resolutionChangedHandler = null;
    this.setResolutionChangedHandler = function(f) {
        this.resolutionChangedHandler = f;
    }

    this.moveToHandler = null;
    this.setMoveToHandler = function(f) {
        this.moveToHandler = f;
    }

    this.extraRightClickFunction = null;
    this.setRightClickFunction = function(f) {
        this.extraRightClickFunction = f;
    }

    this.last_domove_timer;
    //this.domove_timer_accum = 0;

    this.updateCurrentCenter = function() {
        var currentx = -findPosX(mymap);
        var currenty = -findPosY(mymap);

        current_center_x = currentx + mymaparea.width / 2;
        current_center_y = currenty + mymaparea.height / 2;
    };

    this.do_mu = function(e) {
        var rightclick;
        if (!e) e = event;
        if (e.which) {
            rightclick = (e.which == 3);
        } else if (e.button) {
            rightclick = (e.button == 2);
        }

        if (rightclick) {
            return false;
        }

        isDown = false;

        mymap.style.cursor = "default";

        // if double-click, set the mouse-click point to be the center
        var now = new Date();
        var diff = now - lastmouseup;
        var sameplace = this._oldClientX2 && this._oldClientY2 && (Math.abs(this._oldClientX2 - e.clientX) < 5 && Math.abs(this._oldClientY2 - e.clientY) < 5);
        this._oldClientX2 = e.clientX;
        this._oldClientY2 = e.clientY;

        if (diff < 300 && sameplace && !isDownAndMoved && MMMap._moveMapWhenDBLClicked) {
            moveCenterToMouseCursor(1);
            this._oldClientX2 = null;
            this._oldClientY2 = null;
        }

        if (!isDownAndMoved) {
            lastmouseup = now.getTime();
        }

        if (browser != "Netscape")
            event.returnValue = false; // Cancel default behavior

        if (mmmap.mouseUpHandler) mmmap.mouseUpHandler();

        return false;
    };

    MMMap._moveMapWhenDBLClicked = true;

    this.setMoveMapWhenDBLClicked = function(_value) {
        MMMap._moveMapWhenDBLClicked = _value;
    }

    this.getMoveMapWhenDBLClicked = function() {
        return MMMap._moveMapWhenDBLClicked; ;
    }

    this.moveTo = function(_lat, _long) {
        latitude = _lat;
        longitude = _long;

        degree_to_pixel = (imagewidth * resolution) / longitude_range;

        var centerposx = parseInt((longitude - minlongitude) / longitude_range * resolution);
        var centerposy = parseInt((maxlatitude - latitude) * degree_to_pixel / imageheight);

        centerpos = centerposy * resolution + centerposx;

        // Calculate cursor positions in pixel
        current_center_x = longToPoint(longitude, resolution);
        current_center_y = latToPoint(latitude, resolution);

        if (current_center_x > 1000000) {
            this.mapoffset.x = parseInt(current_center_x / 1000000) * 1000000;
            current_center_x = current_center_x % 1000000;
        } else {
            this.mapoffset.x = 0;
        }
        if (current_center_y > 1000000) {
            this.mapoffset.y = parseInt(current_center_y / 1000000) * 1000000;
            current_center_y = current_center_y % 1000000;
        } else {
            this.mapoffset.y = 0;
        }

        this.showCenterAt(centerpos);

        this.moveToCurrent();

        if (this.moveToHandler) this.moveToHandler();
    };

    this.moveLeft = function(step) {
        current_center_x = current_center_x - step;
        this._updateVisibles();
        this.moveToCurrent();
        if (this.moveToHandler) this.moveToHandler();
    };

    this.moveRight = function(step) {
        current_center_x = current_center_x + step;
        this._updateVisibles();
        this.moveToCurrent();
        if (this.moveToHandler) this.moveToHandler();
    };

    this.moveUp = function(step) {
        current_center_y = current_center_y - step;
        this._updateVisibles();
        this.moveToCurrent();
        if (this.moveToHandler) this.moveToHandler();
    };

    this.moveDown = function(step) {
        current_center_y = current_center_y + step;
        this._updateVisibles();
        this.moveToCurrent();
        if (this.moveToHandler) this.moveToHandler();
    };

    this.getWhere = function(who) {

        var T = 0, L = 0;
        while (who != null) {
            if (who.offsetWidth != undefined) {
                L += parseInt(who.offsetLeft);
                T += parseInt(who.offsetTop);
                who = who.offsetParent;
            }
        }
        return { 'left': L, 'top': T };
    }

    this.showZoomBar = function() {
        document.getElementById("resolution_bar_div").style.visibility = "visible";
        document.getElementById("span_current_resolution_text_div").style.visibility = "visible";
    }

    this.hideZoomBar = function() {
        document.getElementById("resolution_bar_div").style.visibility = "hidden";
        document.getElementById("span_current_resolution_text_div").style.visibility = "hidden";
    }

    this.showModeSelector = function() {
        document.getElementById("MMMAP_modeselector").style.visibility = "visible";
    }

    this.hideModeSelector = function() {
        document.getElementById("MMMAP_modeselector").style.visibility = "hidden";
    }

    this.rePaint = function() {
        this.showCenterAt(centerpos);
        this.drawScale();
        this.moveToCurrent();

        this.drawCenterMark();

        this.updateVisibleLatLong();

        // zoom bar
        var mapdiv_right = mymaparea.width;
        var mapdiv_bottom = mymaparea.height;

        var barspace = parseInt(document.getElementById("resolution_bar_div").style.width.replace("px", "")) + 10;
        var tmpdiv = document.getElementById("span_current_resolution_text_div");

        var mybottom = mapdiv_bottom - 35;
        var myleft = mapdiv_right - barspace - 70;
        tmpdiv.style.top = mybottom + "px";
        tmpdiv.style.left = myleft + "px";

        tmpdiv = document.getElementById("resolution_bar_div");
        mybottom = mapdiv_bottom - 38;
        myleft = mapdiv_right - barspace;
        tmpdiv.style.top = mybottom + "px";
        tmpdiv.style.left = myleft + "px";

        // mode selector
        var modeselector = document.getElementById("MMMAP_modeselector");
        modeselector.style.right = "12px";

        if (this.mmruler) {
            this.mmruler.rePaint();
        }
        if (this.canvas) {
            this.canvas.rePaint();
        }
    };

    this.moveToCurrent = function() {
        var startx = -1 * (parseInt(current_center_x - mymaparea.style.width.replace("px", "") / 2));
        var starty = -1 * (parseInt(current_center_y - mymaparea.style.height.replace("px", "") / 2));

        mymap.style.left = startx + "px";
        mymap.style.top = starty + "px";

        this.updateVisibleLatLong();
        this.redrawCustomDivs();
    };

    this.hideCenterMark = function() {
        document.getElementById("MMMAP_center_point").style.visibility = "hidden";
    };

    this.showCenterMark = function() {
        document.getElementById("MMMAP_center_point").style.visibility = "visible";
    }

    this.drawCenterMark = function() {
        var tmpleft = mymaparea.width / 2 - center_point.offsetWidth / 2;
        center_point.style.left = tmpleft + "px";

        var tmptop = mymaparea.height / 2 - center_point.offsetHeight / 2;

        // HACK, FIXME
        if (browser == "IE") {
            tmptop += 2;
        } else {
            //tmptop -= 2;
        }

        center_point.style.top = tmptop + "px";

        center_point.onmousedown = this.do_md;
        center_point.onmouseup = this.do_mu;
        center_point.onmousemove = this.do_move;
    };

    this.updateVisibleLatLong = function() {
        // update visible_min|max_latitude|longitude

        var visible_min_x = current_center_x - mymaparea.width / 2;
        var visible_max_x = current_center_x + mymaparea.width / 2;

        var visible_min_y = current_center_y - mymaparea.height / 2;
        var visible_max_y = current_center_y + mymaparea.height / 2;

        visible_min_latitude = pointToLat(visible_max_y, resolution);
        visible_max_latitude = pointToLat(visible_min_y, resolution);

        visible_min_longitude = pointToLong(visible_min_x, resolution);
        visible_max_longitude = pointToLong(visible_max_x, resolution);
    }

    this._updateVisibles = function() {
        // Update the centerpos and re-run showCenterAt(centerpos)
        // based on current_center_x and current_center_y

        latitude = mmmap.centerLat();
        longitude = mmmap.centerLong();

        this.updateVisibleLatLong();

        var visiblex = parseInt((current_center_x + this.mapoffset.x) / imagewidth);
        var visibley = parseInt((current_center_y + this.mapoffset.y) / imageheight);

        var visible = visiblex + visibley * resolution;

        if (centerpos != visible) {
            centerpos = visible; //middle element
            //setTimeout('showCenterAt(centerpos)',0);
            this.showCenterAt(centerpos);

            // some of them might become visible
            this.redrawCustomDivs();
        }

    };

    this.showCenterAt = function(visible) {
        if (!visible && visible != 0) {
            return;
        };

        var x = visible % resolution;
        var y = parseInt(visible / resolution);

        if (this.doBlurImages) {
            this.setBlurVisible(x, y);
            this.setBlurVisible(x - 1, y);
            this.setBlurVisible(x + 1, y);

            this.setBlurVisible(x, y - 1);
            this.setBlurVisible(x, y + 1);

            this.setBlurVisible(x - 1, y - 1);
            this.setBlurVisible(x - 1, y + 1);
            this.setBlurVisible(x + 1, y - 1);
            this.setBlurVisible(x + 1, y + 1);
        }

        this.setVisible(x, y);
        this.setVisible(x - 1, y);
        this.setVisible(x + 1, y);

        this.setVisible(x, y - 1);
        this.setVisible(x, y + 1);

        this.setVisible(x - 1, y - 1);
        this.setVisible(x - 1, y + 1);
        this.setVisible(x + 1, y - 1);
        this.setVisible(x + 1, y + 1);

        if (this.numtiles >= 5) {
            if (this.doBlurImages) {
                this.setBlurVisible(x - 2, y);
                this.setBlurVisible(x + 2, y);

                this.setBlurVisible(x, y - 2);
                this.setBlurVisible(x, y + 2);

                this.setBlurVisible(x - 2, y - 1);
                this.setBlurVisible(x + 2, y - 1);
                this.setBlurVisible(x - 2, y + 1);
                this.setBlurVisible(x + 2, y + 1);

                this.setBlurVisible(x - 1, y - 2);
                this.setBlurVisible(x + 1, y - 2);
                this.setBlurVisible(x - 1, y + 2);
                this.setBlurVisible(x + 1, y + 2);

                this.setBlurVisible(x - 2, y - 2);
                this.setBlurVisible(x + 2, y - 2);
                this.setBlurVisible(x - 2, y + 2);
                this.setBlurVisible(x + 2, y + 2);
            }

            this.setVisible(x - 2, y);
            this.setVisible(x + 2, y);

            this.setVisible(x, y - 2);
            this.setVisible(x, y + 2);

            this.setVisible(x - 2, y - 1);
            this.setVisible(x + 2, y - 1);
            this.setVisible(x - 2, y + 1);
            this.setVisible(x + 2, y + 1);

            this.setVisible(x - 1, y - 2);
            this.setVisible(x + 1, y - 2);
            this.setVisible(x - 1, y + 2);
            this.setVisible(x + 1, y + 2);

            this.setVisible(x - 2, y - 2);
            this.setVisible(x + 2, y - 2);
            this.setVisible(x - 2, y + 2);
            this.setVisible(x + 2, y + 2);
        }

        if (this.numtiles >= 7) {
            var tmp = Math.floor(this.numtiles / 2);
            for (var i = 0; i <= tmp; i++) {
                for (var j = 0; j <= tmp; j++) {

                    if (i >= 3 || j >= 3) {
                        this.setVisible(x - i, y - j);
                        this.setVisible(x + i, y + j);

                        this.setVisible(x + i, y - j);
                        this.setVisible(x - i, y + j);
                    }
                }
            }
        }
    };

    this.setAllRealImagesUsed = function() {
        for (var i = 0; i < numimages * numimages; i++) {
            usedAs[i] = -1;
            var imageObject = images[i];
            imageObject.src = "http://mmmap15.longdo.com//mmmap/images/empty-transparent.png";
        }
        if (this.ovl_enable) {
            for (var i = 0; i < this.__layers.length; i++) {
                for (var j = 0; j < numimages * numimages; j++) {
                    this.ovl_images[i][j].style.visibility = "hidden";
                    this.ovl_images[i][j].src = "http://mmmap15.longdo.com//mmmap/images/empty-transparent.png";
                }
            }
        }
    };

    this.setAllOverlayImagesUsed = function() {
        if (this.ovl_enable) {
            for (var i = 0; i < this.__layers.length; i++) {
                for (var j = 0; j < numimages * numimages; j++) {
                    this.ovl_images[i][j].style.visibility = "hidden";
                    this.ovl_images[i][j].src = "http://mmmap15.longdo.com//mmmap/images/empty-transparent.png";
                }
            }
        }
    };

    this.setAllImagesUsed = function() {
        for (var i = 0; i < numimages * numimages; i++) {
            usedAs[i] = -1;
            var imageObject = images[i];
            imageObject.src = "http://mmmap15.longdo.com//mmmap/images/empty.png";
            document.getElementById('blur_' + imageObject.id).src = "http://mmmap15.longdo.com/mmmap/images/empty-transparent.png";
            document.getElementById('blur_' + imageObject.id).style.visibility = "hidden";
        }
        if (this.ovl_enable) {
            for (var i = 0; i < this.__layers.length; i++) {
                for (var j = 0; j < numimages * numimages; j++) {
                    this.ovl_images[i][j].style.visibility = "hidden";
                    this.ovl_images[i][j].src = "http://mmmap15.longdo.com//mmmap/images/empty-transparent.png";
                }
            }
        }
    };

    this.hideAllBlurImages = function() {
        for (var i = 0; i < numimages * numimages; i++) {
            var imageObject = images[i];
            document.getElementById('blur_' + imageObject.id).style.visibility = "hidden";
            document.getElementById('blur_' + imageObject.id).src = "http://mmmap15.longdo.com//mmmap/images/empty-transparent.png";
        }
    };

    this.setAllImagesUsedButNotSetToEmpty = function() {
        for (var i = 0; i < numimages * numimages; i++) {
            usedAs[i] = -1;
        }
    };

    // IE 8
    this.mapoffset = { x: 0, y: 0 };

    this.calcBBox = function(x, y) {
        var degree_to_pixel = (imagewidth * resolution) / longitude_range;
        var x1 = (x * imagewidth / degree_to_pixel + minlongitude);
        var y1 = (maxlatitude - y * imageheight / degree_to_pixel);
        var x2 = ((x + 1) * imagewidth / degree_to_pixel + minlongitude);
        var y2 = (maxlatitude - (y + 1) * imageheight / degree_to_pixel);

        //return "97.5,17.5,100,20";
        return x1 + "," + y2 + "," + x2 + "," + y1;
    }

    this.setVisible = function(_x, _y) {
        if (_x < 0 || _x >= resolution || _y < 0 || _y >= resolution) {
            return;
        };

        var imgid = _y * resolution + _x;
        var myimgid = imgid * 923456789;

        if (imgid < 0 || imgid >= resolution * resolution) {
            return;
        };

        var x = _x % numimages;
        var y = _y % numimages;

        var objidx = x + y * numimages;

        // return if I'm already visible
        if (usedAs[objidx] == imgid) {
            return;
        }

        var imageObject = images[objidx];
        var imageObject_div = document.getElementById("div_" + images[objidx].id);

        usedAs[objidx] = imgid;

        //imageObject.src= "http://mmmap15.longdo.com//mmmap/images/empty-transparent.png";

        imageObject.src = "http://ms22.longdo.com/mmmap/img.php?res=" + resolution + "&imgid=" + myimgid + "&mode=" + this.mapmode + "&c=1&key=d9c8884535ae82504c4962ce47a4cae4";

        // FIXME temp
        if (this.mapmode.match(/transp/)) {
            imageObject.src = "http://ms22t.longdo.com/mmmap/img.php?res=" + resolution + "&imgid=" + myimgid + "&mode=" + this.mapmode + "&c=1&key=d9c8884535ae82504c4962ce47a4cae4";
        }

        var leftpos = (parseInt(imgid % resolution) * imagewidth);
        var toppos = (parseInt(imgid / resolution) * imageheight);

        // IE 8 seems to overflow at 1,342,177.27
        leftpos -= this.mapoffset.x;
        toppos -= this.mapoffset.y;

        imageObject_div.style.left = leftpos + "px";
        imageObject_div.style.top = toppos + "px";

        if (this.ovl_enable) {
            var d = new Date();
            var timestamp = parseInt(d.getTime() / 60000);

            for (var i = 0; i < this.__layers.length; i++) {
                if (this.__layers[i].status != "active") {
                    continue;
                }
                if (this.__layers[i].startzoom > this.getZoom() || this.__layers[i].stopzoom < this.getZoom()) {
                    continue;
                }
                this.ovl_images[i][objidx].style.visibility = "hidden";
                this.ovl_images[i][objidx].style.zIndex = this.__layers[i].zIndex;
                if (this.__layers[i].opacity) {
                    var tmpopac = this.__layers[i].opacity;
                    this.ovl_images[i][objidx].style.opacity = tmpopac;
                    this.ovl_images[i][objidx].style.filter = "alpha(opacity=" + parseInt(tmpopac * 100) + ")";
                }

                var imgurl = "";
                if (this.__layers[i].layertype == "WMS") {
                    imgurl = this.__layers[i].url + "?WIDTH=" + imagewidth + "&HEIGHT=" + imageheight + "&SRS=EPSG%3A4326&STYLES=&LAYERS=" + encodeURIComponent(this.__layers[i].layers) + "&BBOX=" + this.calcBBox(_x, _y);
                    if (this.__layers[i].extra) imgurl += this.__layers[i].extra;

                } else if (this.__layers[i].layertype == "LONGDO") {
                    imgurl = this.__layers[i].url + "?res=" + resolution + "&imgid=" + myimgid + "&mode=" + this.__layers[i].mode + "&c=1&key=d9c8884535ae82504c4962ce47a4cae4";
                    if (this.__layers[i].nocache && this.__layers[i].nocache != 0) {
                        imgurl += "&nocache=" + this.__layers[i].nocache;
                    }
                }

                if (imgurl != "") {
                    this.ovl_images[i][objidx].tmpsrc = imgurl;

                    if (this.__layers[i].nocache && this.__layers[i].nocache != 0) {
                        this.ovl_images[i][objidx].src = this.ovl_images[i][objidx].tmpsrc + "&rnd=" + timestamp;
                    } else {
                        this.ovl_images[i][objidx].src = this.ovl_images[i][objidx].tmpsrc;
                    }

                    this.ovl_images[i][objidx].onload = function() {
                        this.style.visibility = "visible";
                    }
                }
            }
        }

        // POI stuff
        var zoom = Math.log(resolution) / Math.log(2);

        hidePOI(objidx);

        if (zoom >= this.showpoi) {
            if (typeof (poi_num[zoom][imgid]) == "undefined") {
                //getPOIs(imgid,objidx,resolution);
                //this._myGetPOIsFunction(imgid,objidx,resolution);
                var command = "mmmap._myGetPOIsFunction(" + imgid + "," + objidx + "," + resolution + ");";
                setTimeout(command, 100 + Math.random() * 1000);
            } else {
                if (poi_num[zoom][imgid] != 0) {
                    // if zero then nothing to draw
                    drawPOIFromArray(zoom, imgid, objidx);
                }
            }
        }
    };

    this.getPOIsByTags = function(imgid, objidx, resolution) {
        if (this.ooi_constraints && this.ooi_constraints.length > 0) {
            var d = new Date;
            var pretagstring = "imgid=" + encodeURIComponent(imgid)
						+ "&dispimg=" + encodeURIComponent(objidx)
						+ "&res=" + encodeURIComponent(resolution)
						+ "&action=getpois"
						+ "&mode=json"
						+ "&map=msn1";
            //+ "&map=ms22";

            var tagstring = "";

            var dorequest = 0;
            var zoom = Math.log(resolution) / Math.log(2);
            for (var i = 0; i < this.ooi_constraints.length; i++) {

                if ((this.ooi_constraints_showlevel_min[i] <= zoom || this.ooi_constraints_showlevel_min[i] == 0)
								&& (this.ooi_constraints_showlevel_max[i] >= zoom || this.ooi_constraints_showlevel_max[i] == 0)
							 ) {
                    tagstring += "&tag[]=" + this.ooi_constraints[i];

                    if (this.ooi_constraints_showlevel_min[i] != 0 || this.ooi_constraints_showlevel_max[i] != 0) {
                        tagstring += "&forceshowlevel[]=" + zoom;
                    } else {
                        tagstring += "&forceshowlevel[]=";
                    }

                    if ((this.ooi_constraints_showlevel_label_min[i] <= zoom || this.ooi_constraints_showlevel_label_min[i] == 0)
									&& (this.ooi_constraints_showlevel_label_max[i] >= zoom || this.ooi_constraints_showlevel_label_max[i] == 0)
								 ) {
                        tagstring += "&iconlabel[]=1";
                    } else {
                        tagstring += "&iconlabel[]=";
                    }

                    tagstring += "&iconmode[]=" + this.ooi_constraints_iconmode[i];
                }
            }

            if (tagstring != "") {
                json_request("http://mmmap15.longdo.com//mmmap/../search/rpc-json.php", pretagstring + tagstring + "&key=d9c8884535ae82504c4962ce47a4cae4", "poisresult", "mmmap.receivePOIsResult();");
            }
            //json_request("http://mmmap15.longdo.com//mmmap/../search/dummy-getpois.php", tagstring, "poisresult", "mmmap.receivePOIsResult");
        }
    }

    // Cluster
    this.getClustersByTags = function(imgid, objidx, resolution) {
        if (!this.ooi_constraints || this.ooi_constraints.length == 0) return;

        var zoom = Math.log(resolution) / Math.log(2);
        var parameter = '';
        for (var i = 0; i < this.ooi_constraints.length; i++) {
            if (this.ooi_constraints_showlevel_min[i] != 0 && zoom < this.ooi_constraints_showlevel_min[i] || this.ooi_constraints_showlevel_max[i] != 0 && zoom > this.ooi_constraints_showlevel_max[i]) continue;
            parameter += '&tag[]=' + this.ooi_constraints[i] + '&iconlabel[]=';

            if ((this.ooi_constraints_showlevel_label_min[i] == 0 || zoom >= this.ooi_constraints_showlevel_label_min[i]) &&
							(this.ooi_constraints_showlevel_label_max[i] == 0 || zoom <= this.ooi_constraints_showlevel_label_max[i])) {
                parameter += '1';
            }

            parameter += "&iconmode[]=" + this.ooi_constraints_iconmode[i];
        }
        if (parameter == '') return;
        json_request('http://mmmap15.longdo.com//mmmap/../search/rpc-json.php', 'mode=json&action=getclusters&imgid=' + imgid + '&resolution=' + resolution + parameter + '&lang=' + mylang + "&key=d9c8884535ae82504c4962ce47a4cae4", 'poi_saved[' + zoom + '][' + imgid + ']', 'mmmap.receiveClustersResult(' + zoom + ',' + imgid + ',' + objidx + ');');
    }

    this.receiveClustersResult = function(zoom, imgid, dispimg) {
        n_pois = poi_saved[zoom][imgid].length;
        poi_num[zoom][imgid] = n_pois;
        drawPOIFromArray(zoom, imgid, dispimg);
        var oldnum = poi_images_num[dispimg];
        if (n_pois < oldnum) {
            for (var i = n_pois; i < oldnum; i++) {
                mymap.removeChild(poi_images[dispimg][i]);
                if (poi_images_label[dispimg][i]) {
                    mymap.removeChild(poi_images_label[dispimg][i]);
                }
            }
        }
        poi_images_num[dispimg] = n_pois;
    }

    // allow user to override this function
    //this._myGetPOIsFunction = this.getPOIsByTags;
    this._myGetPOIsFunction = this.getClustersByTags;

    this.setMyGetPOIsFunction = function(f) {
        this._myGetPOIsFunction = f;
    }

    this.setBlurVisible = function(_x, _y) {
        if (_x < 0 || _x >= resolution || _y < 0 || _y >= resolution) {
            return;
        };

        var imgid = _y * resolution + _x;
        var myimgid = imgid * 923456789;

        // return if minus or exceed the limit
        if (imgid < 0 || imgid >= resolution * resolution) {
            return;
        };

        var x = _x % numimages;
        var y = _y % numimages;

        var objidx = x + y * numimages;

        var imageObject = images[objidx];
        var imageObject_div = document.getElementById("div_" + images[objidx].id);

        var blurImageObject = document.getElementById("blur_" + images[objidx].id);

        // show parent image first
        var parent_resolution = (resolution / 2);
        var parent_imgid = (parent_resolution * parseInt(_y / 2) + parseInt(_x / 2)) * 923456789;
        var xoffset = (_x % 2 == 0) ? 0 : -320;
        var yoffset = (_y % 2 == 0) ? 0 : -240;

        blurImageObject.width = imagewidth * 2;
        blurImageObject.height = imageheight * 2;

        blurImageObject.style.left = xoffset + "px";
        blurImageObject.style.top = yoffset + "px";

        // FIXME temp
        if (this.mapmode.match(/transp/)) {
            blurImageObject.src = "http://ms22t.longdo.com/mmmap/img.php?res=" + parent_resolution + "&imgid=" + parent_imgid + "&mode=" + this.mapmode + "&c=1&key=d9c8884535ae82504c4962ce47a4cae4";
        } else {
            blurImageObject.src = "http://ms22.longdo.com/mmmap/img.php?res=" + parent_resolution + "&imgid=" + parent_imgid + "&mode=" + this.mapmode + "&c=1&key=d9c8884535ae82504c4962ce47a4cae4";
        }


        blurImageObject.style.visibility = "visible";

        var leftpos = (parseInt(imgid % resolution) * imagewidth);
        var toppos = (parseInt(imgid / resolution) * imageheight);

        leftpos -= this.mapoffset.x;
        toppos -= this.mapoffset.y;

        imageObject_div.style.left = leftpos + "px";
        imageObject_div.style.top = toppos + "px";

        imageObject.style.visibility = "hidden";
        imageObject.onload = function() {
            document.getElementById('blur_' + this.id).style.visibility = "hidden";
            document.getElementById('blur_' + this.id).src = "http://mmmap15.longdo.com//mmmap/images/empty-transparent.png";
            this.style.visibility = "visible";
        }
    };

    this.showScale = function() {
        document.getElementById("MMMAP_scale").style.visibility = "visible";
    };

    this.hideScale = function() {
        document.getElementById("MMMAP_scale").style.visibility = "hidden";
    };

    this.drawScale = function() {
        var x_pixel_range = resolution * imagewidth;
        var y_pixel_range = resolution * imageheight;

        var kmPerXPixel = this.getKmPerLong() * longitude_range / x_pixel_range;

        var pixel = 500 / kmPerXPixel; // pixel per 5 km
        var text = "500 km";

        if (pixel > 250) {
            pixel = pixel / 5;
            text = "100 km";

            if (pixel > 250) {
                pixel = pixel / 2;
                text = "50 km";

                if (pixel > 250) {
                    pixel = pixel / 5;
                    text = "10 km";

                    if (pixel > 250) {
                        pixel = pixel / 2;
                        text = "5 km";

                        if (pixel > 250) {
                            pixel = pixel / 5;
                            text = "1 km";

                            if (pixel > 250) {
                                pixel = pixel / 2;
                                text = "500 m";

                                if (pixel > 250) {
                                    pixel = pixel / 5;
                                    text = "100 m";

                                    if (pixel > 250) {
                                        pixel = pixel / 2;
                                        text = "50 m";
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        document.getElementById("MMMAP_scale").innerHTML = "";

        if (this.mapmode.match(/dark/)) {
            jg.setColor("#FFFFFF");
        } else {
            jg.setColor("#000000");
        }
        jg.setStroke(2);
        jg.drawLine(5, 30, 5 + pixel, 30);

        jg.drawLine(5, 20, 5, 30);
        jg.drawLine(5 + pixel, 20, 5 + pixel, 30);

        var scalestep = pixel / 5;

        jg.drawLine(5 + scalestep, 25, 5 + scalestep, 30);
        jg.drawLine(5 + scalestep * 2, 25, 5 + scalestep * 2, 30);
        jg.drawLine(5 + scalestep * 3, 25, 5 + scalestep * 3, 30);
        jg.drawLine(5 + scalestep * 4, 25, 5 + scalestep * 4, 30);

        jg.drawString(text, 5 + pixel / 2 - 20, 5);

        jg.paint();
    };

    this.setDisplayRes = function(newresolution) {
        // only show the new resolution number in the display
        document.getElementById("span_current_resolution").innerHTML = Math.log(newresolution) / Math.log(2);
    }

    this.findAppropriateZoom = function(points) {
        if (!points || points.length == 0) {
            return this.getZoom();
        }
        var max_lat, max_long, min_lat, min_long;
        max_lat = min_lat = latitude;
        max_long = min_long = longitude;

        for (var i = 0; i < points.length; i++) {
            if (points[i][0] < min_long) min_long = points[i][0];
            if (points[i][0] > max_long) max_long = points[i][0];
            if (points[i][1] < min_lat) min_lat = points[i][1];
            if (points[i][1] > max_lat) max_lat = points[i][1];
        }

        var my_visible_min_latitude = visible_min_latitude;
        var my_visible_max_latitude = visible_max_latitude;
        var my_visible_min_longitude = visible_min_longitude;
        var my_visible_max_longitude = visible_max_longitude;
        var span_lat = (my_visible_max_latitude - my_visible_min_latitude) / 2;
        var span_long = (my_visible_max_longitude - my_visible_min_longitude) / 2;
        var zoomminus = 0;

        while ((my_visible_min_latitude > min_lat
							|| my_visible_max_latitude < max_lat
							|| my_visible_min_longitude > min_long
							|| my_visible_max_longitude < max_long) && this.getZoom() - zoomminus >= 3) {
            zoomminus++;
            my_visible_min_latitude -= span_lat * zoomminus;
            my_visible_max_latitude += span_lat * zoomminus;
            my_visible_min_longitude -= span_long * zoomminus;
            my_visible_max_longitude += span_long * zoomminus;
        }

        return this.getZoom() - zoomminus;
    }

    this.setZoom = function(_zoom) {
        this.setRes(Math.pow(2, _zoom));
    }

    this.getZoom = function() {
        return this.zoom;
    }

    this.getResolution = function() {
        return Math.pow(2, this.zoom);
    }

    this.doBlurImages = false;

    this.setRes = function(newresolution) {
        if (newresolution == resolution) {
            document.getElementById("span_current_resolution").innerHTML = Math.log(resolution) / Math.log(2);
            slider1.setValue(Math.log(resolution) / Math.log(2));
            this.zoom = Math.log(resolution) / Math.log(2);
            return;
        }

        if (newresolution > max_resolution) {
            newresolution = max_resolution;
        } else if (newresolution < min_resolution) {
            newresolution = min_resolution;
        }

        if (newresolution / resolution != 2 || this.currentmode != "mm") {
            this.setAllImagesUsed(); // otherwise we will see the old images when dragging coz we do not have preloaded images for blur yet
            //this.doBlurImages = true;
        } else {
            this.setAllOverlayImagesUsed();
            this.doBlurImages = true;
        }

        hideAllPOIs();

        resolution = newresolution;
        this.zoom = Math.log(resolution) / Math.log(2);

        document.getElementById("span_current_resolution").innerHTML = Math.log(resolution) / Math.log(2);

        slider1.setValue(Math.log(resolution) / Math.log(2));

        degree_to_pixel = (imagewidth * resolution) / longitude_range;

        var centerposx = parseInt((longitude - minlongitude) / longitude_range * resolution);
        var centerposy = parseInt((maxlatitude - latitude) * degree_to_pixel / imageheight);

        centerpos = centerposy * resolution + centerposx;

        // Calculate cursor positions in pixel
        current_center_x = parseInt((longitude - minlongitude) * degree_to_pixel);
        current_center_y = parseInt((maxlatitude - latitude) * degree_to_pixel);

        if (current_center_x > 1000000) {
            this.mapoffset.x = parseInt(current_center_x / 1000000) * 1000000;
            current_center_x = current_center_x % 1000000;
        } else {
            this.mapoffset.x = 0;
        }
        if (current_center_y > 1000000) {
            this.mapoffset.y = parseInt(current_center_y / 1000000) * 1000000;
            current_center_y = current_center_y % 1000000;
        } else {
            this.mapoffset.y = 0;
        }

        this.showCenterAt(centerpos);

        this.drawScale();

        // FIXME global var
        if (showingmark)
            setMarksVisible();

        this.moveToCurrent();

        showCurrentRoads(false);

        this.redrawCustomDivs();

        updateLocationDetailPopupPosition();

        if (this.vectorvisible) {
            this.__setVectorDivPos();
        }

        this.doBlurImages = false;
        if (mmmap.resolutionChangedHandler) mmmap.resolutionChangedHandler();
    };

    this.showtexttip = function(x, y, title, text) {
        tt = document.getElementById('_mmmap_texttip');
        if (tt.timer) clearTimeout(tt.timer);
        if (tt.timer_detail) clearTimeout(tt.timer_detail);
        tt.timer = false;

        tt.fulltext = text;
        tt.innerHTML = "<div style=\"top:16px;border: 1px solid rgb(102, 102, 102); padding: 5px; overflow: visible; font-family: 'Tahoma'; font-size: 8pt; line-height: normal; position: relative; background-color: rgb(255, 255, 153); white-space: nowrap;\">" + text + "</div>";
        tt.style.display = 'none';
        tt.style.whiteSpace = 'nowrap';
        tt.style.overflow = 'visible';
        tt.style.left = (x - parseInt(tt.parentNode.style.left.replace("px", ""))) + 'px';
        if (typeof (parseInt(tt.parentNode.style.top.replace("px", ""))) == 'number' && typeof ((tt.parentNode.parentNode.parentNode.style.top.replace("px", ""))) == 'number') {
            tt.style.top = (y - parseInt(tt.parentNode.style.top.replace("px", "")) - parseInt(tt.parentNode.parentNode.parentNode.style.top.replace("px", "")) - this.getWho(this.getMapDiv()).top) + 'px';
            tt.timer_detail = setTimeout("document.getElementById('_mmmap_texttip').style.display='block';", 400);
            //		    tt.timer_detail = setTimeout("document.getElementById('_mmmap_texttip').innerHTML = \"" + text.replace(/"/g,"\\\"") + "\";",500);
        }
    };

    this.getWho = function(who) {
        var T = 0, L = 0;
        while (who != null) {
            if (who.offsetLeft != undefined) {
                L += parseInt(who.offsetLeft);
                T += parseInt(who.offsetTop);
                who = who.offsetParent;
            }
        }
        return { 'left': L, 'top': T };
    }

    this.updatetexttiplocation = function(x, y, force) {
        tt = document.getElementById('_mmmap_texttip');
        if ((tt.style.display == 'none') || (force)) {
            tt.style.left = x - parseInt(tt.parentNode.style.left);
            tt.style.top = y - parseInt(tt.parentNode.style.top) - this.getWho(this.getMapDiv()).top; // - parseInt(tt.parentNode.parentNode.parentNode.style.top);
        }
    }

    this.hidetexttipdelay = function(msec) {
        tt = document.getElementById("_mmmap_texttip");
        if (tt.timer) clearTimeout(tt.timer);
        if (tt.timer_detail) clearTimeout(tt.timer_detail);
        tt.timer_detail = false;
        tt.timer = setTimeout("document.getElementById('_mmmap_texttip').style.display = 'none'", msec);
    };

    this.cancelhidetexttip = function() {
        tt = document.getElementById("_mmmap_texttip");
        if (tt.timer) clearTimeout(tt.timer);
        if (tt.timer_detail) clearTimeout(tt.timer_detail);
        tt.timer_detail = false;
        tt.timer = false;
    }

    gsshapemin = function(e) {
        if (this.isselect == 1) return false;
        if (mmmap.mapvector[this.shid].lineobject) {
            if ((typeof (document.MMCanvas) != 'undefined' && document.MMCanvas.drawing != false) || document.pointdraging) return false;
            if (this.showeditlinetimer) clearTimeout(this.showeditlinetimer);
            if (mmmap.mapvector[this.shid].lineobject.enableedit) {
                mmmap.mapvector[this.shid].lineobject.editLineEnable(true);
            }
        }
        if (!e) var e = window.event;
        if (e.pageX || e.pageY) {
            posx = e.pageX;
            posy = e.pageY;
        } else if (e.clientX || e.clientY) {
            posx = e.clientX + document.body.scrollLeft + document.documentElement.scrollLeft;
            posy = e.clientY + document.body.scrollTop + document.documentElement.scrollTop;
        }

        if ((!mmmap.mapvector[this.shid].showtip || mmmap.mapvector[this.shid].showtip == false) && mmmap.mapvector[this.shid].title != '') {
            mmmap.showtexttip(posx - 5, posy + 1, mmmap.mapvector[this.shid].title, mmmap.mapvector[this.shid].tiptext);
            mmmap.mapvector[this.shid].showtip = true;
        }


        mmmap.updatetexttiplocation(posx - 5, posy + 1, false);

        if (this.ownerSVGElement) {
            attr = "stroke";
            attrw = "stroke-width";
        } else {
            attr = "strokecolor";
            attrw = "strokeweight";
        }

        if (mmmap.mapvector[this.shid].shape.length) {
            for (var i = 0; i < mmmap.mapvector[this.shid].shape.length; i++) {
                o = mmmap.mapvector[this.shid].shape[i];

                o.style.zIndex = '9999';

                if (typeof (o.lineobject) != 'undefined') {
                    if (o.lineobject.user_defined_popup_content != "" || o.lineobject.showeditpopup) {
                        this.style.cursor = 'pointer';
                    }
                }

                if (!o.oldcolorsave) {
                    o.oldcolor = o.getAttribute(attr) + "";
                    o.oldwidth = o.getAttribute(attrw) + "";
                    o.oldcolorsave = true;
                }

                if (mmmap.vectorhilightenable && (!o.currentcolor || (o.currentcolor == 'normal'))) {
                    if (mmmap.vectorhilightmethod.match('width') == "width") {
                        o.setAttribute(attrw, o.oldwidth * mmmap.vectorhilightwidthfactor);
                    }

                    if (mmmap.vectorhilightmethod.match('color') == "color") {
                        o.setAttribute(attr, mmmap.vectorhilightcolor);
                    } else if (mmmap.vectorhilightmethod.match('darker') == "darker") {
                        var color = new RGBColor(o.getAttribute(attr) + "");
                        color.r -= (color.r > mmmap.vectorhilightdiffamount) ? mmmap.vectorhilightdiffamount : 0;
                        color.g -= (color.g > mmmap.vectorhilightdiffamount) ? mmmap.vectorhilightdiffamount : 0;
                        color.b -= (color.b > mmmap.vectorhilightdiffamount) ? mmmap.vectorhilightdiffamount : 0;
                        this.setAttribute(attr, color.toHex());
                    } else if (mmmap.vectorhilightmethod.match('lighter') == "lighter") {
                        var color = new RGBColor(o.getAttribute(attr) + "");
                        color.r += (color.r > (255 - mmmap.vectorhilightdiffamount)) ? 0 : mmmap.vectorhilightdiffamount;
                        color.g += (color.g > (255 - mmmap.vectorhilightdiffamount)) ? 0 : mmmap.vectorhilightdiffamount;
                        color.b += (color.b > (255 - mmmap.vectorhilightdiffamount)) ? 0 : mmmap.vectorhilightdiffamount;
                        o.setAttribute(attr, color.toHex());
                    }

                    o.currentcolor = 'hilight';
                }
            }
        } else {
            if (!this.oldcolorsave) {
                this.oldcolor = this.getAttribute(attr) + "";
                this.oldwidth = this.getAttribute(attrw) + "";
                this.oldcolorsave = true;
            }

            if (mmmap.vectorhilightenable && (!this.currentcolor || (this.currentcolor == 'normal'))) {
                if (mmmap.vectorhilightmethod.match('width') == "width") {
                    this.setAttribute(attrw, this.oldwidth * mmmap.vectorhilightwidthfactor);
                }

                if (mmmap.vectorhilightmethod.match('color') == "color") {
                    this.setAttribute(attr, mmmap.vectorhilightcolor);
                } else if (mmmap.vectorhilightmethod.match('darker') == "darker") {
                    var color = new RGBColor(this.getAttribute(attr) + "");
                    color.r -= (color.r > mmmap.vectorhilightdiffamount) ? mmmap.vectorhilightdiffamount : 0;
                    color.g -= (color.g > mmmap.vectorhilightdiffamount) ? mmmap.vectorhilightdiffamount : 0;
                    color.b -= (color.b > mmmap.vectorhilightdiffamount) ? mmmap.vectorhilightdiffamount : 0;
                    this.setAttribute(attr, color.toHex());
                } else if (mmmap.vectorhilightmethod.match('lighter') == "lighter") {
                    var color = new RGBColor(this.getAttribute(attr) + "");
                    color.r += (color.r > (255 - mmmap.vectorhilightdiffamount)) ? 0 : mmmap.vectorhilightdiffamount;
                    color.g += (color.g > (255 - mmmap.vectorhilightdiffamount)) ? 0 : mmmap.vectorhilightdiffamount;
                    color.b += (color.b > (255 - mmmap.vectorhilightdiffamount)) ? 0 : mmmap.vectorhilightdiffamount;
                    this.setAttribute(attr, color.toHex());
                }
                if (mmmap.mapvector[this.shid].lineobject) {
                    if (mmmap.mapvector[this.shid].lineobject.user_defined_popup_content != "" || mmmap.mapvector[this.shid].lineobject.showeditpopup) {
                        this.style.cursor = 'pointer';
                    }
                }
                this.currentcolor = 'hilight';
                this.parentNode.appendChild(this);
            }
        }

    }

    this.showeditlinetimer = false;

    gsshapemout = function(e) {
        //noBubble(e);
        if (this.isselect == 1) return false;
        if (this.ownerSVGElement) {
            attr = "stroke";
            attrw = "stroke-width";
        } else {
            attr = "strokecolor";
            attrw = "strokeweight";
        }
        if (mmmap.mapvector[this.shid].lineobject) {
            this.showeditlinetimer = setTimeout("mmmap.mapvector[" + this.shid + "].lineobject.editLineEnable(false)", 0);
        }

        mmmap.hidetexttipdelay(100);
        mmmap.mapvector[this.shid].showtip = false;


        if (mmmap.mapvector[this.shid].shape.length) {
            for (var i = 0; i < mmmap.mapvector[this.shid].shape.length; i++) {
                o = mmmap.mapvector[this.shid].shape[i];
                if (o.oldcolor) {
                    if (typeof (this.lineobject) != 'undefined' && typeof (this.lineobject.linecolor) != 'undefined' && this.lineobject.linecolor != '') {
                        mmmap.mapvector[this.shid].shape[i].oldcolor = this.lineobject.linecolor; //if lineobject avaliable use lineobject
                        if (typeof (this.lineobject.linewidth) != 'undefined')
                            mmmap.mapvector[this.shid].shape[i].oldwidth = this.lineobject.linewidth;
                        mmmap.mapvector[this.shid].shape[i].linewidth = this.lineobject.linewidth;
                    }
                    o.setAttribute(attr, o.oldcolor);
                    o.setAttribute(attrw, o.oldwidth);
                    o.oldcolorsave = false;
                    o.currentcolor = 'normal';
                    o.style.zIndex = (typeof (o.lineobject) != 'undefined') ? o.lineobject.zIndex : 0;
                    o.style.cursor = 'normal';
                }
            }
        } else {
            if (this.oldcolor) {
                if (typeof (this.lineobject) != 'undefined' && typeof (this.lineobject.linecolor) != 'undefined' && this.lineobject.linecolor != '') { //if lineobject avaliable use lineobject
                    this.oldcolor = this.lineobject.linecolor;
                    if (typeof (this.lineobject.linewidth) != 'undefined')
                        this.oldwidth = this.lineobject.linewidth;
                    this.linewidth = this.lineobject.linewidth;
                    this.lineobject.rePaint();
                }
                this.setAttribute(attr, this.oldcolor);
                this.setAttribute(attrw, this.oldwidth);
                this.oldcolorsave = false;
                this.currentcolor = 'normal';
                this.style.cursor = 'normal';
            }
        }
    }

    gsshapeclick = function(e) {
        if (typeof (this.lineobject) != 'undefined') {
            if (this.lineobject.edit == 1) {
                return false;
            }
            else {
                if (typeof (document.selectedShape) != 'undefined' && document.selectedShape != '') {
                    if (document.MMCanvas.drawing != false) return false;
                    var seletedshape = document.selectedShape;
                    seletedshape.isselect = 0;
                }
                else if (this.lineobject.handler) {
                    this.lineobject.handler.lineobject = this.lineobject;
                    if (typeof (this.lineobject.handler.onclick) == 'function') this.lineobject.handler.onclick();
                }
                else if (this.lineobject.editPopup) {
                    if (this.lineobject.showeditpopup) {
                        document.selectedShape = this;
                        this.isselect = 1;
                        this.lineobject.editLineEnable(false);
                        this.lineobject.editPopup();
                    } else {
                        if (this.lineobject.user_defined_popup_content != "") {
                            this.lineobject.showUserDefinedPopup(this.lineobject.user_defined_popup_content);
                        }
                    }
                }

            }
        }
        var midpoint = 0;
        if (mmmap.mapvector[this.shid].type != 'ellipse') midpoint = Math.floor(mmmap.mapvector[this.shid].points.length / 2);
        if (mmmap.mapvector[this.shid].pointmode) {
            y = mmmap.mouseCursorLat();
            x = mmmap.mouseCursorLong();
        } else {
            if (mmmap.mapvector[this.shid].type != 'ellipse') {
                x = mmmap.mapvector[this.shid].points[midpoint][0];
                y = mmmap.mapvector[this.shid].points[midpoint][1];
            }
            else {
                x = mmmap.mapvector[this.shid].lon;
                y = mmmap.mapvector[this.shid].lat;
            }
        }
        detail = mmmap.mapvector[this.shid].detail;
        if (mmmap.mapvector[this.shid].detailpopup) {
            detail = mmmap.mapvector[this.shid].detailpopup;
            mmmap.showPopUp(y, x, mmmap.mapvector[this.shid].title, detail);
        }

        //alert(mmmap.mapvector[this.shid].lineobject);
        if (mmmap.mapvector[this.shid].lineobject) {
            //document.getElementById("delete_this_line").onmousedown = function(){alert('test');}//mmmap.mapvector[this.shid].lineobject.clearLine;
            //document.getElementById("delete_this_line").innerHTML = 'Delete';
            //alert("after:"+document.getElementById("delete_this_line").onmousedown);
        }
        mmmap.hidetexttipdelay(0);

    }

    this.gssetcolor = function(color) {
        this.gsfgcolor = color;
    }

    this.gsSetPolyFillColor = function(color) {
        this.gsfillcolor = color;
    }

    this.gsSetEventsHandler = function(lineobject, eventshandler) {
        this.gseventshandler = eventshandler;
        this.lineobject = lineobject;
    }

    this.gssetopacity = function(opac) {
        this.gsopacity = opac;
    }

    this.gssetlinewidth = function(width) {
        this.gslinewidth = width;
    }

    this.gssetshapeattr = function(shape, attr, value) {
        if (shape.length) {
            for (var i = 0; i < shape.length; i++)
                shape[i].setAttribute(attr, value);
        } else {
            shape.setAttribute(attr, value);
        }
    }

    this.hidevector = function() {
        this.vectorvisible = false;
        if (this.updatevectortimer) clearTimeout(this.updatevectortimer);
        this.updatevectortimer = setTimeout("mmmap.updatevector();", 100);
    };

    this.showvector = function() {
        this.vectorvisible = true;
        if (this.updatevectortimer) clearTimeout(this.updatevectortimer);
        this.updatevectortimer = setTimeout("mmmap.updatevector();", 100);
    };

    this.updatevector_attach = function(onreq, onsucc) {
        this.updatevectoronreq = onreq;
        this.updatevectoronsucc = onsucc;
    };

    this.updatevector = function() {
        if (this.updatevectortimer) this.updatevectortimer = false;
        this.updatevectoronreq();
        setTimeout("mmmap.updatevector_do();", 10);
    }

    this.redrawlinestimer = false;
    this.redrawlinescomplete = false;

    this.reDrawLines = function() {
        this.mapvector_currentzoom = -1;
        this.updatevector_do();
        this.redrawlinescomplete = true;
    }
    this.updatevector_do = function() {
        this.__setVectorDivPos();
        //this.mapvector_currentzoom = -1; // FIXME why do I have to call this inorder to have it shown in IE

        var uv_v, uv_z, uv_i, o, olat, olong;
        //if (this.updatevectortimer) this.updatevectortimer = false;
        //this.updatevectoronreq();

        if ((updatevector_lock == false) && this.vectorvisible) {
            updatevector_lock = true;
            uv_v = document.getElementById("_mmmap_vector_div");
            uv_v.style.visibility = 'visible';
            uv_z = this.zoom;

            // update div position
            vmin_y = latToPoint(visible_max_latitude, resolution) - 200;
            vmax_y = latToPoint(visible_min_latitude, resolution) + 200;
            vmin_x = longToPoint(visible_min_longitude, resolution) - 200;
            vmax_x = longToPoint(visible_max_longitude, resolution) + 200;

            vmin3_y = latToPoint(visible_max_latitude, 32768) - 100 * (32768 / resolution);
            vmax3_y = latToPoint(visible_min_latitude, 32768) + 100 * (32768 / resolution);
            vmin3_x = longToPoint(visible_min_longitude, 32768) - 100 * (32768 / resolution);
            vmax3_x = longToPoint(visible_max_longitude, 32768) + 100 * (32768 / resolution);
            degree_to_pixel = (imagewidth * resolution) / longitude_range;

            if (typeof (uv_v.gs) == 'undefined') {
                uv_v.gs = new allgs(uv_v);
            } else {
                if (this.mapvector_currentzoom != uv_z)
                    uv_v.gs.clear();
            }

            if (this.vectorsize_h) {
                uv_v.gs.setHeight(this.vectorsize_h);
                uv_v.gs.setWidth(this.vectorsize_w);
            }

            var widthfactoradd = Math.floor(resolution / 512);
            for (uv_i = 1; uv_i < this.mapvector.length; uv_i++) {
                o = this.mapvector[uv_i];
                //if(typeof(o)!='undefined') if(o.shape) alert(this.mapvector[uv_i].shape.length+':'+o.lineobject);

                if (o.enable == true) {
                    if (this.vectorvisible) {
                        if (o.pointmode) {
                            // ox[min,max] oy[min,max]
                            oy = [o.points[0][1], o.points[0][1]];
                            ox = [o.points[0][0], o.points[0][0]];

                            for (var j = 1; j < o.points.length; j++) {
                                if (oy[0] > o.points[j][1]) oy[0] = o.points[j][1];
                                if (oy[1] < o.points[j][1]) oy[1] = o.points[j][1];

                                if (ox[0] > o.points[j][0]) ox[0] = o.points[j][0];
                                if (ox[1] < o.points[j][0]) ox[1] = o.points[j][0];
                            }

                            visible = ((uv_z >= o.zoom[0]) && (uv_z <= o.zoom[1]) &&
											((oy[1] > vmin3_y && oy[1] < vmax3_y)
											 || (oy[0] > vmin3_y && oy[0] < vmax3_y)
											 || (oy[0] < vmin3_y && oy[1] > vmax3_y))
											&& ((ox[1] > vmin3_x && ox[1] < vmax3_x)
												|| (ox[0] > vmin3_x && ox[0] < vmax3_x)
												|| (ox[0] < vmin3_x && ox[1] > vmax3_x))
											);

                        } else {
                            // lat[max,min], long[min,max]
                            // to be fix
                            if (o.points) {
                                olat = [o.points[0][1], o.points[0][1]];
                                olong = [o.points[0][0], o.points[0][0]];
                            }
                            else {
                                olat = [o.lat, o.lat];
                                olong = [o.lon, o.lon];
                            }
                            if (o.points) {
                                for (var j = 1; j < o.points.length; j++) {
                                    if (olat[0] < o.points[j][1]) olat[0] = o.points[j][1];
                                    if (olat[1] > o.points[j][1]) olat[1] = o.points[j][1];

                                    if (olong[0] > o.points[j][0]) olong[0] = o.points[j][0];
                                    if (olong[1] < o.points[j][0]) olong[1] = o.points[j][0];
                                }
                            }

                            visible = ((uv_z >= o.zoom[0]) && (uv_z <= o.zoom[1]) &&
											((olat[1] > visible_min_latitude && olat[1] < visible_max_latitude)
											 || (olat[0] > visible_min_latitude && olat[0] < visible_max_latitude)
											 || (olat[1] < visible_min_latitude && olat[0] > visible_max_latitude))
											&& ((olong[1] > visible_min_longitude && olong[1] < visible_max_longitude)
												|| (olong[0] > visible_min_longitude && olong[0] < visible_max_longitude)
												|| (olong[0] < visible_min_longitude && olong[1] > visible_max_longitude))
											);
                        }
                    }
                    if (this.vectorvisible && (visible == true) && (this.mapvector_currentzoom != uv_z || typeof (o.shape) == 'undefined')) {
                        // draw
                        o.tiptext = "<div style='font-weight: Bold;white-space:nowrap'>" + o.title + "</div>";
                        if (o.detail != "") {
                            o.tiptext += "<div>" + o.detail + "</div>";
                        }
                        if (true) { //o.type == 'polyline' || o.type == 'ellipse' || o.type == 'line' || o.type == 'polygon'
                            // calculate points
                            if (typeof (o.calpt) == 'undefined')
                                o.calpt = [];
                            if (o.points) {
                                if (typeof (o.calpt[resolution]) == 'undefined') {
                                    var newpoints = [];
                                    for (var i = 0; i < o.points.length; i++) {
                                        if (o.pointmode) {
                                            newpoints[i] = [(o.points[i][0] / (32768 / resolution)) - this.mapoffset.x, (o.points[i][1] / (32768 / resolution)) - this.mapoffset.y, o.points[i][2]];
                                        } else {
                                            newpoints[i] = [longToPoint(o.points[i][0], resolution) - this.mapoffset.x, latToPoint(o.points[i][1], resolution) - this.mapoffset.y, o.points[i][2]];
                                        }
                                    }
                                    o.calpt[resolution] = newpoints;
                                }
                            }
                            else {
                                o.calpt[resolution] = [latToPoint(o.lat, resolution), longToPoint(o.lon, resolution)];
                            }
                            uv_v.gs.setfgcolor(o.color);
                            uv_v.gs.setlinewidth(o.lineobject ? o.lineobject.linewidth : o.linewidth); // + widthfactoradd <-- increase line width after zoom 8
                            if (o.type == 'ellipse') {
                                var cw = Math.abs(o.calpt[resolution][1] - longToPoint(((1 / this.getKmPerLong() * o.width) + o.lon), resolution));
                                var ch = Math.abs(o.calpt[resolution][0] - latToPoint(((1 / this.getKmPerLat() * o.height) + o.lat), resolution));
                                var cx = o.calpt[resolution][1] - cw - this.mapoffset.x;
                                var cy = o.calpt[resolution][0] - ch - this.mapoffset.y;
                                if (typeof (o.fillcolor) != 'undefined' || typeof (o.lineobject) != 'undefined') {
                                    uv_v.gs.setbgcolor((o.fillcolor) ? o.fillcolor : o.lineobject.fillcolor);
                                }
                                if (typeof (o.fillcolor) != 'undefined' || typeof (o.lineobject) != 'undefined') {
                                    uv_v.gs.setbgopacity((o.fillopacity) ? o.fillopacity : o.lineobject.fillopacity);
                                }
                                if (typeof (o.lineobject) != 'undefined') uv_v.gs.setopacity(o.lineobject.lineopacity);
                                o.shape = uv_v.gs.drawEllipse(cx, cy, cw * 2, ch * 2, o.lineobject);
                                uv_v.gs.setbgcolor('none');
                            }
                            else {
                                uv_v.gs.setopacity(o.opacity);
                                o.shape = uv_v.gs.createpoly(o.calpt[resolution], o.lineobject);
                            }
                        }

                        // always hilight
                        if (true) {
                            if (o.shape.length) {
                                for (var i = 0; i < o.shape.length; i++) {
                                    o.shape[i].onmousemove = gsshapemin;
                                    o.shape[i].onmouseout = gsshapemout;
                                    o.shape[i].onclick = gsshapeclick;
                                    o.shape[i].shid = uv_i;
                                    if (!o.show) o.shape[i].style.visibility = 'hidden';
                                    if (typeof (o.shape[i].lineobject) != 'undefined') {
                                        o.shape[i].style.zIndex = o.shape[i].lineobject.zIndex;
                                        o.shape[i].lineobject.vector = o;
                                        o.shape[i].renderer = 'vml';
                                    }
                                }
                            } else {
                                //alert('MM -> '+o.shape.lineobject+' -> '+o.shape.length);
                                o.shape.onmousemove = gsshapemin;
                                o.shape.onmouseout = gsshapemout;
                                o.shape.onclick = gsshapeclick;
                                //o.shape.onmousedown = gsshapeclick;
                                if (!o.show) o.shape.style.visibility = 'hidden';
                                if (typeof (o.shape.lineobject) != 'undefined')
                                    o.shape.lineobject.vector = o;
                            }
                        }
                        o.shape.shid = uv_i;

                        uv_v.gs.update();

                    } else {
                        if (this.mapvector_currentzoom != uv_z && (typeof (o.shape) != 'undefined')) {
                            //uv_v.removeChild(o.shape);
                            if (o.shape.length && o.shape.length > 0) {
                                //												for(var i =0;i<o.shape.length;i++)
                                for (var i in o.shape)
                                    if (o.shape[i].parentNode)
                                    o.shape[i].parentNode.removeChild(o.shape[i]);
                            } else {
                                o.shape.parentNode.removeChild(o.shape);
                            }
                            delete o.shape;
                        }
                    }
                } else {
                    // deleted remove
                    if ((o.enable == false) && (typeof (o.shape) != 'undefined')) {
                        //uv_v.removeChild(o.shape);
                    }
                }

            }

            uv_v.gs.update();
            this.mapvector_currentzoom = this.zoom;
            updatevector_lock = false;
        } else {
            if (!this.vectorvisible) {
                document.getElementById("_mmmap_vector_div").style.visibility = 'hidden';
            }
        }

        this.updatevectoronsucc();
        if (!this.redrawlinescomplete) {
            document.MMMap = this;
            if (this.redrawlinestimer) clearTimeout(this.redrawlinestimer);
            this.redrawlinestimer = setTimeout("document.MMMap.reDrawLines()", 500);
        }
    }

    this.drawLine = function(x1, y1, x2, y2, startzoom, stopzoom, title, detail, detailpopup, pointmode) {
        line_id = this.mapvector.length;
        this.mapvector[line_id] = new Object();
        this.mapvector[line_id].enable = true;
        this.mapvector[line_id].title = title;
        this.mapvector[line_id].detail = detail;
        this.mapvector[line_id].detailpopup = detailpopup;
        this.mapvector[line_id].type = 'line';
        this.mapvector[line_id].points = [[x1, y1], [x2, y2]];
        this.mapvector[line_id].zoom = [startzoom, stopzoom];
        this.mapvector[line_id].div = null;
        this.mapvector[line_id].color = this.gsfgcolor;
        this.mapvector[line_id].opacity = this.gsopacity;
        this.mapvector[line_id].linewidth = this.gslinewidth;
        this.mapvector[line_id].pointmode = pointmode;

        if (this.updatevectortimer) clearTimeout(this.updatevectortimer);
        this.updatevectortimer = setTimeout("mmmap.updatevector();", 200);

        return line_id;
    };

    this.drawPolyline = function(points, startzoom, stopzoom, title, detail, detailpopup, pointmode, lineobject) {
        if (!points || points.length == 0) {
            return -1;
        }
        line_id = this.mapvector.length;
        this.mapvector[line_id] = new Object();
        this.mapvector[line_id].type = 'polyline';
        this.mapvector[line_id].enable = true;
        this.mapvector[line_id].title = title;
        this.mapvector[line_id].detail = detail;
        this.mapvector[line_id].detailpopup = detailpopup; //(typeof(lineobject)!='undefined' && lineobject.user_defined_popup_content!='') ? lineobject.user_defined_popup_content:detailpopup;
        this.mapvector[line_id].points = points;
        this.mapvector[line_id].zoom = [startzoom, stopzoom];
        this.mapvector[line_id].div = null;
        this.mapvector[line_id].color = this.gsfgcolor;
        this.mapvector[line_id].opacity = this.gsopacity;
        this.mapvector[line_id].linewidth = this.gslinewidth;
        this.mapvector[line_id].pointmode = pointmode;
        this.mapvector[line_id].lineobject = lineobject;
        this.mapvector[line_id].id = line_id;
        this.mapvector[line_id].show = true;

        if (typeof (this.mapvector[line_id].lineobject) != 'undefined') {
            this.mapvector[line_id].type = (this.mapvector[line_id].lineobject.mode == '1') ? 'line' : 'polygon';
            this.mapvector[line_id].lineobject.allvector = this.mapvector;
        }

        if (this.updatevectortimer) clearTimeout(this.updatevectortimer);
        this.updatevectortimer = setTimeout("mmmap.updatevector();", 200);

        return line_id;
    };

    this.getVector = function(vid) {
        if (this.mapvector[vid])
            return this.mapvector[vid];
        else
            return -1;
    }

    this.drawEllipse = function(lat, lon, startzoom, stopzoom, attr, lineobject) { //title,detail, detailpopup, width, height, 
        if (!attr.width || !lat || !lon) {
            return false;
        }
        line_id = this.mapvector.length;
        this.mapvector[line_id] = new Object();
        this.mapvector[line_id].enable = true;
        this.mapvector[line_id].title = attr.title;
        this.mapvector[line_id].detail = (attr.description) ? attr.description : "";
        this.mapvector[line_id].detailpopup = attr.detailpopup; //(typeof(lineobject)!='undefined' && lineobject.user_defined_popup_content!='') ? lineobject.user_defined_popup_content:detailpopup;
        this.mapvector[line_id].type = 'ellipse';
        this.mapvector[line_id].lat = lat;
        this.mapvector[line_id].lon = lon;
        this.mapvector[line_id].zoom = [startzoom, stopzoom];
        this.mapvector[line_id].div = null;
        this.mapvector[line_id].color = (attr.linecolor) ? attr.linecolor : this.gsfgcolor;
        this.mapvector[line_id].opacity = (attr.lineopacity) ? attr.lineopacity : this.gsopacity;
        this.mapvector[line_id].linewidth = (attr.linewidth) ? attr.linewidth : this.gslinewidth;
        this.mapvector[line_id].fillcolor = (attr.fillcolor) ? attr.fillcolor : 'none';
        this.mapvector[line_id].fillopacity = (attr.fillopacity) ? attr.fillopacity : 1;
        this.mapvector[line_id].width = attr.width;
        this.mapvector[line_id].height = (typeof (attr.height) != 'undefined') ? attr.height : attr.width;
        this.mapvector[line_id].lineobject = lineobject;
        this.mapvector[line_id].id = line_id;
        this.mapvector[line_id].show = true;
        if (typeof (this.mapvector[line_id].lineobject) != 'undefined')
            this.mapvector[line_id].lineobject.allvector = this.mapvector;

        if (this.updatevectortimer) clearTimeout(this.updatevectortimer);
        this.updatevectortimer = setTimeout("mmmap.updatevector();", 200);

        return line_id;
    };

    this.drawPolygon = function(points, startzoom, stopzoom, title, detail, detailpopup, pointmode, lineobject) {
        if (!points || points.length == 0) {
            return -1;
        }
        line_id = this.mapvector.length;
        this.mapvector[line_id] = new Object();
        this.mapvector[line_id].enable = true;
        this.mapvector[line_id].title = title;
        this.mapvector[line_id].detail = detail;
        this.mapvector[line_id].detailpopup = detailpopup;
        this.mapvector[line_id].type = 'polyline';
        this.mapvector[line_id].points = points;
        this.mapvector[line_id].zoom = [startzoom, stopzoom];
        this.mapvector[line_id].div = null;
        this.mapvector[line_id].color = this.gsfgcolor;
        this.mapvector[line_id].opacity = this.gsopacity;
        this.mapvector[line_id].linewidth = this.gslinewidth;
        this.mapvector[line_id].pointmode = pointmode;
        this.mapvector[line_id].lineobject = lineobject;


        if (this.updatevectortimer) clearTimeout(this.updatevectortimer);
        this.updatevectortimer = setTimeout("mmmap.updatevector();", 200);

        return line_id;
    }

    // possible types are all (default), polyline (line or polygon), ellipse
    this.removeAllVectors = function(type) {
        if (typeof (type) == 'undefined') type = 'all';
        for (var i = 0; i < this.mapvector.length; i++) {
            var obj = this.mapvector[i];
            if (obj && (type == 'all' || obj.type == type)) {
                this.removeVector(obj.id);
            }
        }
    }

    this.removeVector = function(gsid) {
        if (gsid <= 0) {
            return;
        }
        o = this.mapvector[gsid]
        o.enable = false;
        if (typeof (o.shape) != 'undefined') {
            if (o.shape.length && o.shape.length > 0) {
                //					for(var i =0;i<o.shape.length;i++)
                for (var i in o.shape)
                    if (o.shape[i].parentNode)
                    o.shape[i].parentNode.removeChild(o.shape[i]);
            } else {
                if (o.shape.parentNode)
                    o.shape.parentNode.removeChild(o.shape);
            }
        }

        delete o.shape;

        if (this.updatevectortimer) clearTimeout(this.updatevectortimer);
        this.updatevectortimer = setTimeout("mmmap.updatevector();", 500);
    }

    // ---- search section

    function gensearchpopup(obj) {
        return obj.name + "<br>" + obj.name_en
    }

    this.search = function(keyword, offset, clat, clong, cfunc) {
        if (offset == null) offset = 0;
        this.clearsearch();
        json_request("http://mmmap15.longdo.com//mmmap/../search/rpc-json.php", "search=" + keyword + "&bookmark=" + offset + "&center_lat=" + clat + "&center_long=" + clong + "&action=search&mode=json" + "&key=d9c8884535ae82504c4962ce47a4cae4", "searchresult", cfunc);
    }

    this.clearsearch = function() {
        if (searchdiv) {
            for (i = 0; i < searchdiv.length; i++) {
                mmmap.removeCustomDivs(searchdiv[i]);
            }
            searchdiv = new Array();
        }

        if (search_shape) {
            for (var i = 0; i < search_shape.length; i++) {
                mmmap.removeVector(search_shape[i]);
            }
            search_shape = new Array();
        }

    }

    this.enableKeyboardShortCuts = function() {
        kh = new KeyBoardEventHandler(document);

        if (kh) {
            kh.addHandler("UpArrow", "mmmap.moveUp(25)");
            kh.addHandler("DownArrow", "mmmap.moveDown(25)");

            kh.addHandler("LeftArrow", "mmmap.moveLeft(25)");
            kh.addHandler("Ctrl+LeftArrow", "mmmap.moveLeft(25)");
            kh.addHandler("RightArrow", "mmmap.moveRight(25)");
            kh.addHandler("Ctrl+RightArrow", "mmmap.moveRight(25)");

            kh.addHandler("Ctrl+UpArrow", "mmmap.setRes(resolution*2)");
            kh.addHandler("+", "mmmap.setRes(resolution*2)");
            kh.addHandler("Shift++", "mmmap.setRes(resolution*2)");
            kh.addHandler("=", "mmmap.setRes(resolution*2)");
            kh.addHandler("Shift+=", "mmmap.setRes(resolution*2)");
            kh.addHandler("k", "mmmap.setRes(resolution*2)");
            kh.addHandler("Z", "mmmap.setRes(resolution*2)");

            kh.addHandler("Ctrl+DownArrow", "mmmap.setRes(resolution/2)");
            kh.addHandler("-", "mmmap.setRes(resolution/2)");
            kh.addHandler("m", "mmmap.setRes(resolution/2)");
            kh.addHandler("X", "mmmap.setRes(resolution/2)");

            kh.addHandler("Esc", "clearAllPopups()");
        }

        // set focus to mymaparea, so that the keyboard shortcuts will work
        if (browser != "Konqueror")
            mymaparea.focus();
    };

    this.setKeyFocusAtMaparea = function() {
        // set focus back for keyboard handler (bad workaround for Firefox)
        if (kh) document.onkeydown = kh.doKeyDown;
    }

    /*
    * Marker = custom div with a default POI dot + pop-up when clicked
    */
    var _num_marker = 0;
    this.createMarker = function(_lat, _long, _title, _detail) {
        var imageObject = document.createElement('img');
        imageObject.src = "http://mmmap15.longdo.com//mmmap/images/brown-dot.gif";
        imageObject.width = 10;
        imageObject.height = 10;
        imageObject.id = 'marker_' + _num_marker;
        imageObject.customdiv_id = this.drawCustomDivWithPopup(imageObject, _lat, _long, _title, _detail);
        return _num_marker++;
    }

    this.deleteMarker = function(_id) {
        markerimage = document.getElementById("marker_" + _id);
        this.removeCustomDivs(markerimage.customdiv_id);
        delete markerimage;
    }

    var custom_divs = new Array();

    /*
    * Draw the given div at the given latitude and longitude in all resolutions
    */

    this.drawCustomDiv = function(_div, _lat, _long, _title, attr) {
        return this.drawCustomDivLevel(_div, _lat, _long, _title, min_zoom, max_zoom, attr);
    }

    this.drawCustomDivWithPopup = function(_div, _lat, _long, _title, _detail, attr) {
        _div.title = _title;
        _div.detail = _detail ? _detail : "";
        _div.mmmapobj = this;
        _div.onclick = function() {
            this.mmmapobj.showPopUp(_lat, _long, this.title, this.detail);
            //showPopup(_lat,_long,this.title,this.detail);
        }
        _div.style.cursor = "pointer";
        return this.drawCustomDiv(_div, _lat, _long, _title, attr);
    }

    this.drawCustomDivLevel = function(_div, _lat, _long, _title, start_zoom, stop_zoom, attr) {
        //showMMMap();

        // add Div to the custom Div array
        //var newobj = new Object();
        newobj = new Object(); // dont put var here or it cant be deleted
        newobj.div = _div;
        newobj.latitude = _lat;
        newobj.longitude = _long;
        newobj.title = _title;
        newobj.start_zoom = start_zoom;
        newobj.stop_zoom = stop_zoom;
        if (attr) {
            newobj.attr = attr;
        }

        // force values
        newobj.width = _div.width;
        newobj.height = _div.height;

        newobj.div.title = _title;

        custom_divs[custom_divs.length] = newobj;

        document.getElementById("custom_div").appendChild(newobj.div);

        this.updateVisibleLatLong();
        this.redrawCustomDivs();

        return custom_divs.length - 1;
    }

    this.drawCustomDivLevelWithPopup = function(_div, _lat, _long, _title, start_zoom, stop_zoom, _detail, attr) {
        // FIXME set maxwidth and maxheight for popup property if defined in attr
        _div.title = _title;
        _div.detail = _detail;
        _div.mmmapobj = this;
        _div.onclick = function() {
            this.mmmapobj.showPopUp(_lat, _long, this.title, this.detail);
            //showPopup(_lat,_long,this.title,this.detail);
        }
        _div.style.cursor = "pointer";
        return this.drawCustomDivLevel(_div, _lat, _long, _title, start_zoom, stop_zoom, attr);
    }

    this.clearCustomDivs = function() {
        custom_divs = new Array();
        document.getElementById("custom_div").innerHTML = "";
    }

    this.hideCustomDivs = function() {
        if (!custom_divs || custom_divs.length <= 0)
            return;

        for (var i = custom_divs.length - 1; i >= 0; i--) {
            var obj = custom_divs[i];
            if (obj && obj.deleted != 1) {
                obj.visibility = "hidden";
            }
        }

        this.redrawCustomDivs();
    }

    this.showCustomDivs = function() {
        if (!custom_divs || custom_divs.length <= 0)
            return;

        for (var i = custom_divs.length - 1; i >= 0; i--) {
            var obj = custom_divs[i];
            obj.visibility = "visible";
        }

        this.redrawCustomDivs();
    }

    this.hideCustomDiv = function(_id) {
        var obj = custom_divs[_id];
        if (obj && obj.deleted != 1) {
            obj.visibility = "hidden";
        }
        this.redrawCustomDivs();
    }

    this.showCustomDiv = function(_id) {
        var obj = custom_divs[_id];
        if (obj && obj.deleted != 1) {
            obj.visibility = "visible";
        }
        this.redrawCustomDivs();
    }

    this.removeCustomDivs = function(_id) {
        //delete custom_divs[_id]; // FIXME make it work
        if (custom_divs[_id] == null || typeof (custom_divs[_id]) == 'undefined') return;
        custom_divs[_id].deleted = 1;

        var custom_div = document.getElementById("custom_div");
        if (custom_divs[_id].div) {
            custom_div.removeChild(custom_divs[_id].div);
            try {
                custom_divs[_id].div.innerHTML = "";
            } catch (err) {
            }
            delete custom_divs[_id].div;
            custom_divs[_id].div = null;
        }

        this.redrawCustomDivs();
        //closeLocationDetailPopup();
    }

    this.getCustomDivHolder = function(_id) {
        if (custom_divs[_id]) {
            return custom_divs[_id];
        }
        else {
            return false;
        }
    }

    this.getCustomDiv = function(_id) {
        //delete custom_divs[_id]; // FIXME make it work
        if (custom_divs[_id]) {
            return custom_divs[_id].div;
        }
        else {
            return false;
        }
    }

    this.showDivAt = function(_div, _lat, _long) {
        var current_zoom = Math.log(resolution) / Math.log(2);

        var tmpleft = longToPoint(_long, resolution);
        tmpleft = tmpleft - _div.offsetWidth / 2;

        var tmptop = latToPoint(_lat, resolution);
        tmptop = tmptop - _div.offsetHeight / 2;

        _div.style.position = "absolute";
        _div.style.left = tmpleft + "px";
        _div.style.top = tmptop + "px";
    }

    this.redrawCustomDivs = function() {
        //this.updatevector();
        if (this.updatevectortimer) clearTimeout(this.updatevectortimer);

        //if (mmmap)
        this.updatevectortimer = setTimeout("if (mmmap) {mmmap.updatevector();}", 100);
        //alert(1);
        if (!custom_divs || custom_divs.length <= 0) {
            return;
        }

        for (var i = custom_divs.length - 1; i >= 0; i--) {
            var obj = custom_divs[i];

            if (obj && obj.visibility != "hidden" && obj.deleted != 1) {

                var current_zoom = Math.log(resolution) / Math.log(2);

                //alert('obj = (' + obj.latitude + ", " + obj.longitude + ") in [" + visible_min_latitude + ", " + visible_min_longitude + " - " + visible_max_latitude + ", " + visible_max_longitude + "]");
                if (current_zoom >= obj.start_zoom && current_zoom <= obj.stop_zoom &&
								obj.latitude > visible_min_latitude && obj.latitude < visible_max_latitude &&
								obj.longitude > visible_min_longitude && obj.longitude < visible_max_longitude
							 ) {
                    obj.div.style.position = "absolute"; // this must be here!

                    var tmpleft = longToPoint(obj.longitude, resolution);

                    //tmpleft = tmpleft - obj.div.style.width.replace("px","") / 2;
                    //alert(obj.div.offsetWidth + ", " + obj.width + ", " + obj.div.clientWidth + ", " + obj.div.style.width);

                    if (obj.attr && obj.attr.centerOffsetX) {
                        tmpleft = tmpleft - obj.attr.centerOffsetX.replace("px", "");
                    }
                    else {
                        if ((!obj.div.offsetWidth || obj.div.offsetWidth == 0) && obj.width) {
                            tmpleft = tmpleft - obj.width / 2;
                        } else {
                            tmpleft = tmpleft - obj.div.offsetWidth / 2;
                        }
                    }

                    var tmptop = latToPoint(obj.latitude, resolution);
                    //tmptop = tmptop - obj.div.style.height.replace("px","") / 2;
                    if (obj.attr && obj.attr.centerOffsetY) {
                        tmptop = tmptop - obj.attr.centerOffsetY.replace("px", "");
                    }
                    else {
                        if ((!obj.div.offsetHeight || obj.div.offsetHeight == 0) && obj.height) {
                            tmptop = tmptop - obj.height / 2;
                        } else {
                            tmptop = tmptop - obj.div.offsetHeight / 2;
                        }
                    }

                    tmpleft -= this.mapoffset.x;
                    tmptop -= this.mapoffset.y;

                    obj.div.style.left = tmpleft + "px";
                    obj.div.style.top = tmptop + "px";
                    obj.div.style.visibility = "visible";
                    if (obj.attr && obj.attr.draggable) {
                        if (window.YAHOO) {
                            dd = new YAHOO.util.DD(obj.div);
                            if (obj.div.style.cursor != 'pointer') obj.div.style.cursor = 'move';
                            dd.obj = obj;
                            dd.mmmap = this;
                            obj.div.onclick = ''; // unset showpop when div clicked, use Yahoo to handle it instead
                            if (typeof (obj.div.detail) != 'undefined') {
                                dd.onMouseUp = function() {
                                    if (this.drop) {
                                        this.drop = false;
                                        return; // drop the div, do nothing
                                    }
                                    this.mmmap.showPopUp(this.obj.latitude, this.obj.longitude, this.obj.title, this.obj.div.detail);
                                }
                            }
                            dd.onInvalidDrop = function() {
                                this.obj.latitude = this.mmmap.mouseCursorLat();
                                this.obj.longitude = this.mmmap.mouseCursorLong();
                                this.mmmap.redrawCustomDivs();
                                this.mmmap.closeLocationDetailPopup();
                                this.drop = true;
                            }
                            obj.div.draggable = true;
                        }
                    }

                    if (obj.attr && obj.attr.cancelmousedown) {
                        obj.div.onmousedown = cancelEvent;
                    }

                } else {
                    obj.div.style.visibility = "hidden";
                }
            } else {
                if (obj.div) {
                    obj.div.style.visibility = "hidden";
                }
            }
        }
    }

    /*
    * Create pop-up at the given location
    */

    this.popupinfo = new Array();

    this.initPopupImages = function() {
        var path = '//mmmap/images/popup/';
        var images = [
					'arrow_down.png',
					'arrow_down_press.png',
					'arrow_up.png',
					'arrow_up_press.png',
					'cross-gray.png',
					'cross-red.png',
					'popup-bottom.png',
					'popup-bottom-left.png',
					'popup-bottom-right.png',
					'popup-left.png',
					'popup-right.png',
					'popup-top.png',
					'popup-top-left.png',
					'popup-top-right.png'
						];
        for (var i = 0; i < images.length; i++) {
            var imgobj = new Image();
            imgobj.src = path + images[i];

        }
    }

    if (window.addEventListener) {
        document.addEventListener('load', this.initPopupImages, false);
    } else {
        document.attachEvent('onload', this.initPopupImages);
    }

    this.showPopUp = function(_lat, _long, _title, _detail, params) {
        if (!_detail || _detail == '') _detail = "&nbsp;";
        var _link = "";
        var _maxwidth = "";
        var _maxheight = "";
        var _fixpopupsize = false;

        if (params) {
            if (params.link) _link = params.link;
            if (params.width) _maxwidth = params.width;
            if (params.height) _maxheight = params.height;
            if (params.fixpopupsize) _fixpopupsize = params.fixpopupsize;
        }

        // FIXME right now supports only one popup
        if (!this.popupinfo[0]) {
            this.popupinfo[0] = new Object();
        }

        // save _lat, _long, ..... to this.popupinfo[this.popupinfo.length]
        var popup_idx = 0;
        this.popupinfo[popup_idx].lat = _lat;
        this.popupinfo[popup_idx].lon = _long;
        this.popupinfo[popup_idx].maxwidth = _maxwidth;
        this.popupinfo[popup_idx].maxheight = _maxheight;
        this.popupinfo[popup_idx].fixpopupsize = _fixpopupsize;
        var _content = "<span style=\"font-size: 10pt;font-family: tahoma,loma\">" + _detail + "</span>";
        //setTimeout("showLocationDetailPopupWithLink(-1,'" + _title + "','" + _long + "','" + _lat + "','" + _link + "','" + _maxwidth + "','" + _maxheight + "','"+ _content.replace(/'/g,"\\'") +"','" + _fixpopupsize + "');",10);
        showLocationDetailPopupWithLink(-1, _title, _long, _lat, _link, _content, popup_idx, params);
    }


    this.showPopUpWithLink = function(_lat, _long, _title, _detail, _link) {
        var params = new Object();
        params.link = _link;
        return this.showPopUp(_lat, _long, _title, _detail, params);
    }

    this.updatePopupContents = function(popup_idx) {
        mmmap_set_popup_div_size(popup_idx);
    }

    this.clearContextMenu = function() {
        var ldbox = window.document.getElementById("context_menu");
        ldbox.style.visibility = "hidden";
    }

    this.search_result_div = null;

    this.setSearchResultsDiv = function(_div) {
        this.search_result_div = _div;
    }

    this.setSearchResults = function(_value) {
        this.search_result = _value;
    }

    this.updateSearchResultsDiv = function() {
        this.search_result_div.innerHTML = this.search_result;
    }

    this.getReverseGeocodeInfo = function() {
        return this._currentlocation;
    }

    this.getNearbyLocations = function() {
        return this._nearbypois;
    }

    this.addControl = function(control) {
        if (!window.YAHOO) {
            setTimeout("_loadScript('http://mmmap15.longdo.com//mmmap/js/yahoo-bundle.js');", 10);
        }
        switch (control) {
            case 'ruler':
                this.mmruler = new this.RulerToolbar(this);
                this.mmruler.initRulerToolbar();
                return this.mmruler;
                break;
            case 'canvas':
                this.canvas = new MMCanvas(this);
                return this.canvas;
                break;
        }
    }

    this.closeLocationDetailPopup = function() {
        var ldbox = window.document.getElementById("location_detail_popup");
        ldbox.style.visibility = "hidden";
    }

    this.initPOIArrays();

    if (!_mapmode || _mapmode == "") {
        _mapmode = "normal";
    }
    this._setMapMode(_mapmode);

    mymap.onmousedown = this.do_md;
    mymaparea.onmousemove = this.do_move;
    mymaparea.onmouseup = this.do_mu;

    this.setSize(this.mapdiv.style.width.replace("px", ""), this.mapdiv.style.height.replace("px", ""));

    var cookie_lat = readCookie("cookie_lat");
    var cookie_long = readCookie("cookie_long");
    var cookie_res = readCookie("cookie_res");
    if (cookie_lat) latitude = cookie_lat;
    if (cookie_long) longitude = cookie_long;
    if (cookie_res) resolution = cookie_res;

    this.setCenter(latitude, longitude, resolution);

    this.enableMouseWheel();
    //this.enableKeyboardShortCuts();

    this.setRememberLastPosition();

    if (document.getElementById('json_scrdiv')) {
        json_init(document.getElementById('json_scrdiv'));
    }

    this.mmruler = false;
    this.showCenterMark();
    this.setMapMode(_mapmode); // including this.rePaint();

} //}}} // MM Map Class

// global functions

function _loadScript(url) {
    var s1 = document.createElement('script');
    s1.src = url;
    document.getElementsByTagName("head")[0].appendChild(s1);
}

function gradually_move(step_x, step_y, dozoom) {
    if (gradually_move_step > 1) {
        current_center_x = current_center_x + step_x;
        current_center_y = current_center_y + step_y;
        mmmap.moveToCurrent();
        gradually_move_step = gradually_move_step - 1;
        setTimeout('gradually_move(' + step_x + ',' + step_y + ',' + dozoom + ')', 30);
        if (mmmap.moveToHandler) mmmap.moveToHandler();

    } else { // 0 last step
        current_center_x = mouse_cursor_x;
        current_center_y = mouse_cursor_y;

        mmmap.moveToCurrent();

        var visiblex = parseInt(current_center_x / imagewidth);
        var visibley = parseInt(current_center_y / imageheight);

        var visible = visiblex + visibley * resolution;
        centerpos = visible; //middle element

        mmmap.showCenterAt(visible);

        latitude = mmmap.centerLat();
        longitude = mmmap.centerLong();

        if (dozoom) {
            mmmap.setZoom(mmmap.getZoom() + dozoom);
        }
        if (mmmap.moveToHandler) mmmap.moveToHandler();
        mmmap.enableMouseWheel();
    }
}

function moveCenterToMouseCursor(dozoom) {
    // gradually move to the center

    mmmap.disableMouseWheel();

    var distance_x = mouse_cursor_x - current_center_x;
    var distance_y = mouse_cursor_y - current_center_y;
    var distance = Math.sqrt(distance_x * distance_x + distance_y * distance_y);

    gradually_move_step = parseInt(distance / 80);

    step_x = parseInt((mouse_cursor_x - current_center_x) / gradually_move_step);
    step_y = parseInt((mouse_cursor_y - current_center_y) / gradually_move_step);

    setTimeout('gradually_move(' + step_x + ',' + step_y + ',' + dozoom + ')', 30);

}

// init from config.php
var numimages = 9;
var imagewidth = 320;
var imageheight = 240;

var minlatitude = 2.2325;
var minlongitude = 86.8962;

var maxlatitude = 23.3075;
var maxlongitude = 114.9962;
var longitude_range = 28.1;

var visible_min_latitude;
var visible_max_latitude;
var visible_min_longitude;
var visible_max_longitude;

// other global vars
//var kmPerLon;
//var kmPerLat;
var degree_to_pixel;

var images = new Array(numimages * numimages);
var usedAs = new Array(numimages * numimages);

var current_center_x;
var current_center_y;
var centerpos;

var mouse_cursor_x, mouse_cursor_y;
var isDown, isDownAndMoved; // for detecting double-click
var lastmouseup;
var poi = "";
var slider1;
var gradually_move_step;
var jg; // graphics object for drawing scale

var ww;
var wh;

var max_resolution = 32768;
var min_resolution = 2;
var min_zoom = Math.log(min_resolution) / Math.log(2);
var max_zoom = Math.log(max_resolution) / Math.log(2);

var resolution_steps = 15;
var poi_images = new Array(81);
var poi_images_label = new Array(81);
var poi_images_num = new Array(81);

var poi_label = new Array(10); //zoom level 0-9

var poi_saved = new Array();
var poi_num = new Array();
var kh; // keyboard handler
var center_point;

var showingmark;

lastX = null;

var _askLocationName_count = 0;
var _poi_count = 0;

var current_roads; // store the current roads to be displayed

function setMarksVisible() {
    var zoom = Math.log(resolution) / Math.log(2);
    for (var i = min_zoom; i <= max_zoom; i++) { // looping through resolutions
        var mark_pointdiv = window.document.getElementById("mark_point" + i);
        if (zoom == i) {
            mark_pointdiv.style.visibility = "visible";
        } else {
            mark_pointdiv.style.visibility = "hidden";
        }
    }
}

function hideMarks() {
    for (var i = min_zoom; i <= max_zoom; i++) { // looping through resolutions
        var mark_pointdiv = window.document.getElementById("mark_point" + i);
        mark_pointdiv.style.visibility = "hidden";
    }
}

function clearMarks() {
    for (var i = min_zoom; i <= max_zoom; i++) { // looping through resolutions
        var mark_pointdiv = window.document.getElementById("mark_point" + i);
        mark_pointdiv.innerHTML = "";
    }
}

function highLightPOI(id) {
    for (var i = min_zoom; i <= max_zoom; i++) { // looping through resolutions
        var mark_pointdiv = window.document.getElementById("mark_point" + i);
        var allimages = mark_pointdiv.childNodes;

        // loooping through all images
        if (allimages.length > 0) {
            for (var j = 0; j < allimages.length; j++) {
                //var mark_pointimagediv = allimages.item(j);
                var mark_pointimagediv = allimages[j];
                if (mark_pointimagediv.poi_id == id) {
                    mark_pointimagediv.src = "http://mmmap15.longdo.com//mmmap/images/red-dot.gif";
                } else {
                    mark_pointimagediv.src = "http://mmmap15.longdo.com//mmmap/images/brown-dot.gif";
                }
            }
        }
    }
}

function drawPOIFromArray(zoom, imgid, dispimg) {
    hidePOI(dispimg);
    //alert(zoom + ", " + imgid + ", " + dispimg + " ==> " + poi_num[zoom][imgid]);
    for (var i = 0; i < poi_num[zoom][imgid]; i++) {
        var tmp = poi_saved[zoom][imgid][i];
        drawPOI(tmp[0], tmp[1], tmp[2], tmp[3], tmp[4], zoom, dispimg, i, tmp[6], tmp[7]);
    }
}

function hideAllPOIs() {
    var i;
    for (i = 0; i < poi_images.length; i++) {
        hidePOI(i);
    }
}

function hidePOI(dispimg) {
    var imageArray = poi_images[dispimg];

    if (!imageArray || imageArray.length == 0)
        return;

    for (var i = 0; i < imageArray.length; i++) {
        var imageObject = poi_images[dispimg][i];
        var labelObject = poi_images_label[dispimg][i];

        if (imageObject) {
            imageObject.style.visibility = "hidden";
        }
        if (labelObject) {
            labelObject.style.visibility = "hidden";
        }
    }
}

function drawPOI(id, name, lat, mylong, status, zoom, dispimg, idx, imagefile, iconlabel) {
    var res = Math.pow(2, zoom);
    var imageObject = poi_images[dispimg][idx];

    if (!imageObject) {
        // poi_images[dispimg][idx] = new Image;
        poi_images[dispimg][idx] = document.createElement('img');
        poi_images[dispimg][idx].style.position = 'absolute';
        poi_images[dispimg][idx].style.zIndex = 500;
        poi_images[dispimg][idx].border = 0;
        if (id > 0) {
            poi_images[dispimg][idx].onmousedown = poiClicked;
            poi_images[dispimg][idx].style.cursor = 'pointer';
        }
        poi_images[dispimg][idx].id = "poi_images-" + dispimg + "-" + idx;
        mymap.appendChild(poi_images[dispimg][idx]);

        imageObject = poi_images[dispimg][idx];
    } else {
        mymap.appendChild(poi_images[dispimg][idx]);
    }

    if (mmmap.ooi_constraints.length > 0) {
        if (imagefile.match(/^http:\/\//)) {
            imageObject.src = imagefile;
        } else if (imagefile == "none") {
            imageObject.src = "http://mmmap15.longdo.com//mmmap/images/icons/blank.gif";
        } else {
            imageObject.src = "http://mmmap15.longdo.com//mmmap/images/icons/" + imagefile;
        }
    }

    var x = longToPoint(mylong, res) - imageObject.width / 2 - mmmap.mapoffset.x;
    var y = latToPoint(lat, res) - imageObject.height / 2 - mmmap.mapoffset.y;

    imageObject.style.left = x + "px";
    imageObject.style.top = y + "px";

    imageObject.style.visibility = "visible";

    if (iconlabel != "") {
        drawPOILabel(dispimg, idx, iconlabel, x + 13, y - 10, 200);
    }

    imageObject.poi_id = id;
    imageObject.title = name;
    imageObject.poi_name = name;
}

function drawPOILabel(dispimg, idx, text, x, y, width) {
    var div = poi_images_label[dispimg][idx];

    var title = text;
    if (text.length > 24) {
        title = text.substr(0, 21) + "...";
    }

    if (!div) {
        div = document.createElement('div');
        poi_images_label[dispimg][idx] = div;
        div.id = "poi_images_label-" + dispimg + "-" + idx;
        div.style.position = "absolute";
        div.style.overflow = "hidden";
        div.style.textAlign = 'left';
        div.style.fontFamily = "Verdana";
        div.style.fontSize = "12px";
        div.style.color = "#000000";
        div.style.zIndex = 450;

        mymap.appendChild(div);

        var tmptextnode = document.createTextNode(title);
        div.appendChild(tmptextnode);

    } else {
        // div already exists
        div.innerHTML = title;
        mymap.appendChild(div);
    }

    div.style.top = y + 'px';
    div.style.left = x + 'px';
    div.style.width = width + 'px';
    div.style.visibility = "visible";

}

var current_roads_div_children_count = 0;

function MMMapclearLines() {
    document.getElementById("current_roads_div").innerHTML = "";
    current_roads_div_children_count = 0;
}

function MMMapdrawDoubleLines(xs, ys, line_color, line_thickness) {
    var newdiv = document.createElement('div');
    var current_roads_div = document.getElementById('current_roads_div');
    current_roads_div.appendChild(newdiv);
    newdiv.id = "current_roads_div_child_" + current_roads_div_children_count++;
    newdiv.style.position = "absolute";

    var newxs = new Array();
    var newys = new Array();

    var newxs_border = new Array();
    var newys_border = new Array();

    for (var i = 0; i < xs.length; i++) {
        newxs[i] = longToPoint(xs[i], resolution) - longToPoint(xs[0], resolution);
        newys[i] = latToPoint(ys[i], resolution) - latToPoint(ys[0], resolution);

        newxs_border[i] = newxs[i] - 2;
        newys_border[i] = newys[i] - 2;
    }

    newdiv.style.left = longToPoint(xs[0], resolution) + "px";
    newdiv.style.top = latToPoint(ys[0], resolution) + "px";

    var newjg = new jsGraphics(newdiv.id);

    newjg.setColor("#8f1103"); // edge
    newjg.setStroke(line_thickness);
    newjg.drawPolyline(newxs_border, newys_border);

    newjg.setColor(line_color);
    newjg.setStroke(line_thickness - 4);
    newjg.drawPolyline(newxs, newys);
    newjg.paint();
}

function MMMapdrawLines(xs, ys, line_color, line_thickness) {
    var newdiv = document.createElement('div');
    var current_roads_div = document.getElementById('current_roads_div');
    current_roads_div.appendChild(newdiv);
    newdiv.id = "current_roads_div_child_" + current_roads_div_children_count++;
    newdiv.style.position = "absolute";

    var newxs = new Array();
    var newys = new Array();

    for (var i = 0; i < xs.length; i++) {
        newxs[i] = longToPoint(xs[i], resolution) - longToPoint(xs[0], resolution);
        newys[i] = latToPoint(ys[i], resolution) - latToPoint(ys[0], resolution);
    }

    newdiv.style.left = longToPoint(xs[0], resolution) + "px";
    newdiv.style.top = latToPoint(ys[0], resolution) + "px";

    var newjg = new jsGraphics(newdiv.id);

    newjg.setColor(line_color);
    newjg.setStroke(line_thickness);
    newjg.drawPolyline(newxs, newys);
    newjg.paint();
}

function MMMapdrawLine(x1, y1, x2, y2) {
    //alert(x1 + ", " + y1 + ", " + resolution);

    var newdiv = document.createElement('div');
    var current_roads_div = document.getElementById('current_roads_div');
    current_roads_div.appendChild(newdiv);
    newdiv.id = "current_roads_div_child_" + current_roads_div_children_count++;
    newdiv.style.position = "absolute";

    var newjg = new jsGraphics(newdiv.id);
    //newjg.setColor("#ff0000"); // red
    newjg.setColor("#0000ff"); // red
    newjg.setStroke(3);

    newjg.drawLine(longToPoint(x1, resolution), latToPoint(y1, resolution), longToPoint(x2, resolution), latToPoint(y2, resolution));
    newjg.paint();
}

function markPoint(id, name, lat, mylong) {

    var imageObject = document.createElement('img');

    // store the location/resolution
    imageObject.mark_lat = lat;
    imageObject.mark_long = mylong;

    imageObject.poi_id = id;
    imageObject.title = name;
    imageObject.onmousedown = poiClicked;
    imageObject.border = 0;
    imageObject.style.zIndex = 1000;
    imageObject.style.cursor = "pointer";

    if (browser == 'IE' && version < 7) {
        imageObject.src = "http://mmmap15.longdo.com/mmmap/images/pin.gif";
    }
    else imageObject.src = "http://mmmap15.longdo.com/mmmap/images/pin.png";

    var attr = { "centerOffsetX": "12px", "centerOffsetY": "48px" };
    mmmap.drawCustomDivWithPopup(imageObject, lat, mylong, name, '', attr);

    var imageShadow = document.createElement('img');

    // store the location/resolution
    imageShadow.mark_lat = lat;
    imageShadow.mark_long = mylong;
    imageShadow.poi_id = id;
    imageShadow.onmousedown = poiClicked;
    imageShadow.border = 0;
    imageShadow.style.zIndex = 900;
    if (browser == 'IE' && version < 7) {
        imageShadow.src = "http://mmmap15.longdo.com/mmmap/images/pin_shadow.gif";
    }
    else imageShadow.src = "http://mmmap15.longdo.com/mmmap/images/pin_shadow.png";

    var attr = { "centerOffsetX": "7px", "centerOffsetY": "3px" };
    mmmap.drawCustomDivWithPopup(imageShadow, lat, mylong, name, '', attr);

    return;
}

function moveToCenter(e) {
    moveCenterToMouseCursor();

    clearPopup();

    // NOT propagate the event
    if (!e) var e = window.event;
    e.cancelBubble = true;
    if (e.stopPropagation) e.stopPropagation();
}

function closeLocationDetailPopup() {
    var ldbox = window.document.getElementById("location_detail_popup");
    ldbox.style.visibility = "hidden";

    var shape = document.selectedShape;
    if (typeof (shape) != 'undefined' && shape != '') {
        shape.isselect = 0;
    }
}

function updateLocationDetailPopupPosition() {
    var ldbox = window.document.getElementById("location_detail_popup");
    if (ldbox.style.visibility != "hidden") {

        var x = ldbox.x;
        var y = ldbox.y;
        var h = ldbox.h;
        var startres = ldbox.startres;

        var newx = x * resolution / ldbox.startres;
        var newy = y * resolution / ldbox.startres - h;

        newx -= mmmap.mapoffset.x;
        newy -= mmmap.mapoffset.y;

        ldbox.style.left = newx + "px";
        ldbox.style.top = newy + "px";
    }
}

function showLocationDetailPopup(myid, title, mylong, lat, contents, popup_idx, params) {
    return showLocationDetailPopupWithLink(myid, title, mylong, lat, "", contents, popup_idx, params);
}

function showLocationDetailPopupWithLink(myid, title, mylong, lat, titlelink, contents, popup_idx, params) {
    if (lastX != null)
        lastX.style.cssText = '';

    var maplink = "";
    var myid_padded = "";

    if (titlelink != "") {
        maplink = titlelink;
    } else if (myid != "" && myid > 0) {
        myid_padded += myid;
        while (myid_padded.length < 8) {
            myid_padded = "0" + myid_padded;
        }
        maplink = '/p/A' + myid_padded + '/map';
    }

    var ldbox = window.document.getElementById("location_detail_popup");
    ldbox.style.pixelLeft = 0;

    if (params && params.cancelmousedown) {
        ldbox.onmousedown = cancelEvent;
    }

    if (maplink != "") var style_title_link = "cursor:pointer; text-decoration:underline; ";

    var title_txt = '<b><font size=-1><div title="' + title + '" id=location_popup_title style="' + style_title_link + 'font-size:10pt; font-family:tahoma,loma; overflow:hidden; white-space:nowrap; position:absolute; top:14px; left:17px; width:auto;" '
		+ (maplink ? ' onclick="window.location=\'' + maplink + '\'"' : '') + '>' + title + '</div></font></b>';

    var popuptitle = window.document.getElementById("popup_title");
    popuptitle.innerHTML = title_txt;

    var imgpath = 'http://mmmap15.longdo.com//mmmap';
    if (browser == 'IE' && version == '6') {
        var bg_div = document.getElementById("popup_top_left");
        bg_div.style.background = "none";
        bg_div.style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(enabled=true,src=" + imgpath + "/images/popup/popup-top-left.png)";

        bg_div = document.getElementById("location_contents_title");
        bg_div.style.background = "none";
        bg_div.style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(enabled=true,sizingMethod=scale,src=" + imgpath + "/images/popup/popup-top.png)";

        bg_div = document.getElementById("popup_top_right");
        bg_div.style.background = "none";
        bg_div.style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(enabled=true,src=" + imgpath + "/images/popup/popup-top-right.png)";

        bg_div = document.getElementById("popup_middle_left");
        bg_div.style.background = "none";
        bg_div.style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(enabled=true,sizingMethod=scale,src=" + imgpath + "/images/popup/popup-left.png)";

        bg_div = document.getElementById("popup_middle_right");
        bg_div.style.background = "none";
        bg_div.style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(enabled=true,sizingMethod=scale,src=" + imgpath + "/images/popup/popup-right.png)";

        bg_div = document.getElementById("popup_bottom_left");
        bg_div.style.background = "none";
        bg_div.style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(enabled=true,src=" + imgpath + "/images/popup/popup-bottom-left.png)";

        bg_div = document.getElementById("locationdetails_contents_bottom");
        bg_div.style.background = "none";
        bg_div.style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(enabled=true,sizingMethod=scale,src=" + imgpath + "/images/popup/popup-bottom.png)";

        bg_div = document.getElementById("popup_bottom_right");
        bg_div.style.background = "none";
        bg_div.style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(enabled=true,src=" + imgpath + "/images/popup/popup-bottom-right.png)";
    }

    var popupcontent = window.document.getElementById("locationdetails_contents");
    popupcontent.innerHTML = contents;

    document.getElementById("close_location_popup").onmousedown = closeLocationDetailPopup;
    mmmap_set_popup_div_size(popup_idx);
    lastX = null;
}

function mmmap_set_popup_div_size(popup_idx, all_images_loaded) {
    var popup = mmmap.popupinfo[popup_idx];
    var maxwidth = popup.maxwidth;
    var maxheight = popup.maxheight;
    var height_zoombarheight = 70; // zoom bar height ~ 70px; 

    /* set default popup width */
    if (maxwidth == undefined || maxwidth == '') maxwidth = parseInt(_mmmap_div.offsetWidth / 2) > 300 ? 300 : parseInt(_mmmap_div.offsetWidth / 2);
    else if (maxwidth < 150) maxwidth = 150;
    else if (maxwidth > _mmmap_div.offsetWidth) maxwidth = _mmmap_div.offsetWidth;
    /* set default popup height */
    if (maxheight == undefined || maxheight == '') maxheight = (!popup.fixpopupsize) ? parseInt(_mmmap_div.offsetHeight - height_zoombarheight) : parseInt(_mmmap_div.offsetHeight / 2);
    else if (maxheight < 150) maxheight = 150;
    else if (maxheight > _mmmap_div.offsetHeight - height_zoombarheight) maxheight = parseInt(_mmmap_div.offsetHeight - height_zoombarheight);

    /* set size each part of popup: title part */
    var height_title = parseInt(document.getElementById("popup_top").style.height.replace("px", ""));
    var width_title_left = parseInt(document.getElementById("popup_top_left").style.width.replace("px", ""));
    var width_title_right = parseInt(document.getElementById("popup_top_right").style.width.replace("px", ""));
    /* set size each part of popup: contents part */
    var width_content_left = parseInt(document.getElementById("popup_middle_left").style.width.replace("px", ""));
    var width_content_right = parseInt(document.getElementById("popup_middle_right").style.width.replace("px", ""));
    /* set size each part of popup: bottom part */
    var height_bottom = parseInt(document.getElementById("popup_bottom").style.height.replace("px", ""));
    var width_bottom_left = parseInt(document.getElementById("popup_bottom_left").style.width.replace("px", ""));
    var width_bottom_right = parseInt(document.getElementById("popup_bottom_right").style.width.replace("px", ""));

    var width_arrow = 15 / 100; // distance between arrow up and arrow down = 15% of popup
    var minwidth_arrow = 30; // but not less than 30px
    var maxwidth_arrow = 55; // and not more than 55px


    var arrow = document.getElementById("locationdetails_contents_scroll_arrow");
    arrow.innerHTML = "";

    var ldbox = window.document.getElementById("location_detail_popup");

    ldbox.style.visibility = "visible";

    if (popup.fixpopupsize != true) {
        var width_title_fixed = false;

        ldbox.style.width = "";
        ldbox.style.height = "";

        var fit_width, fit_height;

        var ldcontent = document.getElementById("locationdetails_contents");
        var ldcontentcenter = document.getElementById("popup_middle");

        var ldtitle = document.getElementById("location_contents_title");
        var title = document.getElementById("location_popup_title");

        if (title.offsetWidth < (maxwidth - width_title_left - width_title_right)) {
            ldtitle.style.minWidth = title.offsetWidth + "px";
            fit_width = title.offsetWidth + width_title_left + width_title_right;
        }
        else {
            width_title_fixed = true;
            ldtitle.style.width = maxwidth - width_title_left - width_title_right + "px";
            fit_width = maxwidth;
        }

        var tmp_contents = window.document.getElementById("tmp_contents");

        if (tmp_contents.style.display == 'none') tmp_contents.style.display = "inline";

        tmp_contents.style.width = "";
        tmp_contents.style.height = "";

        if (!all_images_loaded) {
            var contents = ldcontent.innerHTML;
            if (contents == '') contents = '&nbsp;';
            tmp_contents.innerHTML = contents;
        }

        var max_height_contents = maxheight - height_title - height_bottom;
        var max_width_contents = maxwidth - width_content_left - width_content_right;
        tmp_contents.style.width = tmp_contents.scrollWidth > max_width_contents ? max_width_contents + "px" : tmp_contents.scrollWidth + "px";
        tmp_contents.style.height = tmp_contents.scrollHeight + 8 > max_height_contents ? max_height_contents + "px" : tmp_contents.scrollHeight + 8 + "px"; // FIXME plus 8 bcoz content's div bigger than temp's div. i don't know, why?

        var content_detail_w = parseInt(tmp_contents.style.width.replace("px", ""));
        var content_detail_h = parseInt(tmp_contents.style.height.replace("px", ""));
        if (fit_width < (content_detail_w + width_content_left + width_content_right)) {
            if ((content_detail_w + width_content_left + width_content_right) < maxwidth) fit_width = content_detail_w + width_content_left + width_content_right;
            else fit_width = maxwidth;
        }
        if (fit_width < (width_bottom_left + width_bottom_right)) {
            fit_width = width_bottom_left + width_bottom_right;
        }

        if ((content_detail_h + height_title + height_bottom) < maxheight)
            fit_height = content_detail_h + height_title + height_bottom;
        else
            fit_height = maxheight;

        ldcontent.style.minWidth = tmp_contents.style.width;
        ldcontent.style.height = tmp_contents.style.height;
        ldcontentcenter.style.height = tmp_contents.style.height;

        /* set width of title, contents; have to fix width bcoz IE not support minwidth,maxwidth,minheight,maxheight */
        if (!width_title_fixed)
            ldtitle.style.width = fit_width > (parseInt(ldtitle.style.minWidth.replace("px", "")) + width_title_left + width_title_right) ? fit_width - width_title_left - width_title_right + "px" : ldtitle.style.minWidth;

        ldcontent.style.width = fit_width > (parseInt(ldcontent.style.minWidth.replace("px", "")) + width_content_left + width_content_right) ? fit_width - width_content_left - width_content_right + "px" : ldcontent.style.minWidth;

        title.style.width = ldtitle.style.width;

        var ldbottomcenter = document.getElementById("locationdetails_contents_bottom");
        ldbottomcenter.style.width = fit_width - width_bottom_left - width_bottom_right + "px";

        ldbox.style.width = fit_width + "px";
        ldbox.style.height = fit_height + "px";

        /* set arrow up & down position */
        var arrow = document.getElementById("locationdetails_contents_scroll_arrow");
        arrow.style.width = (width_arrow * fit_width) < minwidth_arrow ? minwidth_arrow + "px" : ((width_arrow * fit_width) > maxwidth_arrow ? maxwidth_arrow + "px" : parseInt(width_arrow * fit_width) + "px"); // fix width 15%; min-width:30px, max-width:55px
        arrow.style.left = parseInt(fit_width / 2 - parseInt(arrow.style.width.replace("px", "")) / 2 - 4) + "px";

        if (ldcontent.getElementsByTagName('img').length > 0) {
            if (!document.popup_images_loaded) mmmap_resize_popup_image_loaded(popup_idx);
            else document.getElementById("tmp_contents").style.display = "none";
        }
        else {
            setTimeout('adj_locationdetails_contents();', 10);
            document.getElementById("tmp_contents").style.display = "none";
        }
    }
    else {  // fix popup size both width & height
        ldbox.style.width = maxwidth + "px";
        ldbox.style.height = maxheight + "px";

        var ldcontent = document.getElementById("locationdetails_contents");
        var ldcontentcenter = document.getElementById("popup_middle");
        ldcontentcenter.style.height = maxheight - height_title - height_bottom + "px";
        ldcontent.style.height = ldcontentcenter.style.height
        ldcontent.style.width = maxwidth - width_content_left - width_content_right + "px";

        var ldtitle = document.getElementById("location_contents_title");
        var title = document.getElementById("location_popup_title");
        ldtitle.style.width = maxwidth - width_title_left - width_title_right + "px";
        title.style.width = ldtitle.style.width;

        var ldbottomcenter = document.getElementById("locationdetails_contents_bottom");
        ldbottomcenter.style.width = maxwidth - width_bottom_left - width_bottom_right + "px";

        var arrow = document.getElementById("locationdetails_contents_scroll_arrow");
        arrow.style.width = (width_arrow * maxwidth) < minwidth_arrow ? minwidth_arrow + "px" : ((width_arrow * maxwidth) > maxwidth_arrow ? maxwidth_arrow + "px" : (width_arrow * maxwidth) + "px"); // fix width 15%; min-width:30px, max-width:55px
        arrow.style.left = maxwidth / 2 - parseInt(arrow.style.width.replace("px", "")) / 2 - 4 + "px";

        setTimeout('adj_locationdetails_contents();', 10);
    }

    /* update popup position */
    var x_4096 = longToPoint(popup.lon, 4096);
    var y_4096 = latToPoint(popup.lat, 4096);
    ldbox.x = x_4096;
    ldbox.y = y_4096;
    ldbox.startres = 4096;

    var h = ldbox.style.height ? parseInt(ldbox.style.height.replace("px", "")) : ldbox.offsetHeight;
    ldbox.h = h - 14;  // 14 = shadow's pixel size of popup image
    updateLocationDetailPopupPosition();

    /* check edge */
    var x = x_4096 * resolution / 4096 - mmmap.mapoffset.x;
    var y = y_4096 * resolution / 4096 - mmmap.mapoffset.y;

    var w = parseInt(ldbox.style.width.replace("px", ""));

    //var rightedge_x = ww - map_rightmargin;
    var rightedge_x = parseInt(mymaparea.width) + _mmmap_div.posX;
    var topedge_y = 0; // myY is relative

    var posX = findPosX(mymap);
    var posY = findPosY(mymap);

    var myX = x + posX;
    var myY = y + posY;

    var edge_x = parseInt(myX) + parseInt(w); ;
    var edge_y = parseInt(myY) - h;

    //window.status = edge_x + " and right edge " + rightedge_x;
    //window.status = edge_y + " and top edge " + topedge_y;
    if (edge_x > rightedge_x) mmmap.moveRight(edge_x - rightedge_x + 10);
    if (edge_y < topedge_y) mmmap.moveUp(topedge_y - edge_y + 10);
}

function mmmap_resize_popup_image_loaded(popup_idx) {
    var tmpcontents = document.getElementById('tmp_contents');
    var ldcontent = document.getElementById('locationdetails_contents');
    var images = tmpcontents.getElementsByTagName('img');

    document.popup_images = images.length;
    document.popup_images_loaded = 0;

    var contents = ldcontent.innerHTML;
    if (document.popup_images > 0) {
        ldcontent.innerHTML = '<font color=brown>Loading...</font>';
    }

    for (var i = 0; i < document.popup_images; i++) {
        images[i].contents = contents;
        images[i].popup_idx = popup_idx;
        images[i].numimages = document.popup_images;
        images[i].allimage = images;
        images[i].onload = function() {
            document.popup_images_loaded++;
            if (document.popup_images_loaded == this.numimages) {
                showDiv('locationdetails_contents', this.contents);
                mmmap_set_popup_div_size(this.popup_idx, true);
                setTimeout('adj_locationdetails_contents();', 10);
                document.getElementById("tmp_contents").style.display = "none";
                document.popup_images_loaded = false;
            }
        }
        /*if(images[i].src.indexOf('?') > 0) images[i].src = images[i].src+'&reloaded';
        else images[i].src = images[i].src+'?reloaded';*/
    }
}

function adj_locationdetails_contents() {
    /* Add arrow up & down, if content higher than div size */
    var o = document.getElementById("locationdetails_contents");
    if (parseInt(o.scrollHeight) - 2 > parseInt(o.style.height.replace("px", ""))) {
        var arrow = document.getElementById("locationdetails_contents_scroll_arrow");
        var tmp = o.innerHTML;
        o.innerHTML = "<div id='locationdetails_contents_scroll' style='overflow: hidden;'>" + tmp + "</div>";
        arrow.innerHTML = "<span onmouseover=\"accident_detail_scroll('locationdetails_contents_scroll',0,1)\"  onmouseout=\"accident_detail_scroll('locationdetails_contents_scroll',0,0)\" style=\"float:left;\"><img src='http://mmmap15.longdo.com//mmmap/images/popup/arrow_up.png' onmouseover=\"this.src='http://mmmap15.longdo.com//mmmap/images/popup/arrow_up_press.png'\"  onmouseout=\"this.src='http://mmmap15.longdo.com//mmmap/images/popup/arrow_up.png'\"></span><span onmouseover=\"accident_detail_scroll('locationdetails_contents_scroll',1,1)\"  onmouseout=\"accident_detail_scroll('locationdetails_contents_scroll',1,0)\" style=\"float:right;\"><img src='http://mmmap15.longdo.com//mmmap/images/popup/arrow_down.png' onmouseover=\"this.src='http://mmmap15.longdo.com//mmmap/images/popup/arrow_down_press.png'\"  onmouseout=\"this.src='http://mmmap15.longdo.com//mmmap/images/popup/arrow_down.png'\"></span>";

        var ldcontentscroll = window.document.getElementById("locationdetails_contents_scroll");
        ldcontentscroll.style.height = parseInt(o.offsetHeight) + "px";
        ldcontentscroll.style.width = parseInt(o.offsetWidth) + "px";
    }
}

accident_detail_scroll_timer = false;
function accident_detail_scroll(divid, dir, flag) {
    if (accident_detail_scroll_timer) {
        clearTimeout(accident_detail_scroll_timer);
        accident_detail_scroll_timer = false;
    }

    if (flag) {
        if (dir == 1) {
            if (document.getElementById(divid).scrollHeight - document.getElementById(divid).scrollTop > document.getElementById(divid).offsetHeight) {
                document.getElementById(divid).scrollTop += 3;
                accident_detail_scroll_timer = setTimeout("accident_detail_scroll('" + divid + "'," + dir + "," + flag + ")", 30);
            }
        } else {
            if (document.getElementById(divid).scrollTop > 0) {
                document.getElementById(divid).scrollTop -= 3;
                accident_detail_scroll_timer = setTimeout("accident_detail_scroll('" + divid + "'," + dir + "," + flag + ")", 30);
            }
        }

    }


}

function noBubble(e) {
    //if (e) event = e;
    if (typeof (e) != 'undefined' && typeof (e.pageX) != 'undefined') event = e;
    event.cancelBubble = true;
}

function showRightClickPopup(x, y) {
    if (lastX != null)
        lastX.style.cssText = '';

    var showlat = Math.round(mmmap.mouseCursorLat() * 100000) / 100000;
    var showlong = Math.round(mmmap.mouseCursorLong() * 100000) / 100000;

    var txt = '<table width=100% border=0 cellspacing=1 cellpadding=5>' +
			'<tr><td bgcolor="#dee7ff" height=5><span style="font-size: 9pt;font-family:loma,tahoma">' +
			'<b><span id="__mmmap_nearby_poi"></span>' +
			'<b><span id="__mmmap_location_description"></span>' +
			'<b><span title="Latitude, longitude (in degree)"><font size=-2 color=gray>(' + showlat + ', ' + showlong + '), </font></span>' +
			'<span title="TH Geocode"><font size=-2 color=gray>' + mmmap.getLatLngInTG(showlat, showlong) + '</font></span>' +
			'</b></span></td></tr>' +
			'<tr><td bgcolor=#FFFFAA>';


    if (mmmap.extraRightClickFunction) {
        txt += mmmap.extraRightClickFunction();
    } else {
        txt += '<span id="move_to_center_text" style="cursor:pointer;text-decoration: underline;font-size: 9pt;font-family:loma,tahoma" title="Move this point the center">' + 'Make this point the center</span>';
        //'<br/><span id="create_url_text" style="cursor:pointer;text-decoration: underline;font-size: 9pt;font-family:loma,tahoma" onmousedown="linkToPage()" title="Link to this page">' + 'Link to this page</span>';
    }

    txt += '<br></td></tr></table>';

    var ldbox = window.document.getElementById("context_menu");
    ldbox.style.cursor = "text";

    ldbox.onmousedown = noBubble;
    ldbox.onmousemove = noBubble;
    ldbox.style.pixelLeft = 0;
    ldbox.style.width = null;

    ldbox.innerHTML = txt;

    if (document.getElementById("move_to_center_text")) {
        document.getElementById("move_to_center_text").onmousedown = moveToCenter;
    }

    var h = ldbox.offsetHeight;
    var w = ldbox.style.width + 6;
    if (w < 215) w = 215;
    if (w > 400) w = 400;
    ldbox.style.width = w + "px";

    //var rightedge_x = ww - map_rightmargin  -  map_leftmargin - w - findPosX(mymap);

    var rightedge_x = mymaparea.width - w - findPosX(mymap);
    //var rightedge_y = wh - map_topmargin  - map_bottommargin - h - findPosY(mymap);

    var rightedge_y = mymaparea.height - h - findPosY(mymap);
    //alert("y is " + y + ", rightedge_y is " + rightedge_y);
    //alert("mymaparea.height is " + mymaparea.height + ", h is " + h);

    //				if ( x > rightedge_x) x = rightedge_x;
    //				if ( y > rightedge_y) y = rightedge_y;

    ldbox.style.left = x + "px";
    ldbox.style.top = y + "px";
    ldbox.style.visibility = "visible";

    lastX = null;


    // show location description
    if (mmmap.showlocationdescription) {
        if (mmmap.getZoom() > 8) {
            showNearbyPOIs(mmmap.mouseCursorLat(), mmmap.mouseCursorLong());
        }
        showLocationDescription(mmmap.mouseCursorLat(), mmmap.mouseCursorLong());
    }
} //}}}

// will execute  processJSONPoi(poi_result);
function showNearbyPOIs(_lat, _long) {
    var langcode = "1";
    if (window.mylang) {
        langcode = (mylang == "en") ? "2" : "1";
    }
    var degree_to_pixel = (imagewidth * mmmap.getResolution()) / longitude_range;
    var myspan = 20 / degree_to_pixel;
    loadJSON("http://search.longdo.com/addr/poi2.php?lat=" + _lat + "&lon=" + _long + "&lang=" + langcode + "&span=" + myspan);
}

function processJSONPoi(result) {
    var mydiv = document.getElementById('__mmmap_nearby_poi');

    var htmlresult = "";
    if (result.length > 0) {
        for (var i = 0; i < result.length && i < 5; i++) {
            if (result[i] && result[i].name != "" && (result[i].showlevel <= mmmap.getZoom() + 1 || mmmap.getZoom >= 13)) {
                var name = result[i].name;
                var code = result[i].code;
                var description = result[i].description;
                var status = result[i].status;
                var icon = result[i].icon;

                if (icon == "") {
                    icon = "greydot.png";
                }
                icon = "http://mmmap15.longdo.com//mmmap/images/icons/" + icon;

                if (code.match(/^P/)) {
                    code_padded = code.replace(/^P/, "");
                    while (code_padded.length < 8) {
                        code_padded = "0" + code_padded;
                    }

                    htmlresult += "<tr><td valign=top><img border=0 src=" + icon + "></td><td>&nbsp<span style='text-decoration: underline;cursor: pointer' onmousedown='mmmap.showObject(\"A" + code_padded + "\", \"LONGDO\")'>" + name + "</span></td></tr>";

                    //} else if (code.match(/^L/)) {
                    //code_padded = code.replace(/^L/, ""); 
                    //htmlresult +=  "<tr><td valign=top><img border=0 src=" + icon +"></td><td>&nbsp<span style='text-decoration: underline;cursor: pointer' onmousedown='mmmap.showObject(\"" + code_padded + "\", \"RID\")'>" + name + "</span></td></tr>";
                }
            }
        }

        if (htmlresult != "") {
            htmlresult = "<table style='border-collapse: separate' border=0 cellpadding=0 cellspacing=0>" + htmlresult + "</table><hr>";

        }
    }

    mmmap._nearbypois = htmlresult;
    mydiv.innerHTML = htmlresult;
}

function showLocationDescription(_lat, _long) {
    var langcode = "1";
    if (window.mylang) {
        langcode = (mylang == "en") ? "2" : "1";
    }
    var mydiv = document.getElementById('__mmmap_location_description');
    mydiv.innerHTML = '<img src="http://mmmap15.longdo.com//mmmap/images/loading-black.gif" border=0><br>';

    mmmap._currentlocation = "";

    loadJSON("http://search.longdo.com/addr/iden.php?lat=" + _lat + "&lon=" + _long + "&lang=" + langcode);
}

function processJSONAddr(result) {
    var mydiv = document.getElementById('__mmmap_location_description');

    var htmlresult = "";
    if (result && result.province && result.province != "") {
        var province = result.province;
        var district = result.amphoe;
        var subdistrict = result.district;
        var postcode = result.postcode;
        var road = result.road;
        var separator = (window.mylang && mylang == "en") ? "," : "";
        //htmlresult = province + " " + postcode + separator + "<br>" + district + separator + " " + subdistrict + "<br>";

        if (road && road != "" && road != "-") {
            htmlresult += road + "<br>";
        }
        htmlresult += subdistrict + separator + " " + district + "<br>"
			+ province + " " + postcode + "<br>";

        mmmap._currentlocation = result;
        mmmap._currentlocation.htmltext = htmlresult;
    }

    mydiv.innerHTML = htmlresult;
}

function loadJSON(url) {
    var headID = document.getElementsByTagName("head")[0];
    var newScript = document.createElement('script');
    newScript.type = 'text/javascript';
    newScript.src = url;
    headID.appendChild(newScript);
}

function clearAllPopups() {
    clearPopup();
    closeLocationDetailPopup();
}

function clearPopup() {
    var ldbox = window.document.getElementById("context_menu");
    ldbox.style.visibility = "hidden";
}

function popUpWindow(url) {
    newwindow = window.open(url, 'name', 'height=300,width=500');
    if (window.focus) { newwindow.focus() }
    return false;
}

function setAllSearchResultsPOIVisible(zoomout_even_if_onscreen) {
    if (mmmap.currentmode == "gmap") return;
    if (!search_results_poi || search_results_poi.length <= 0)
        return;

    clearMarks();

    var sumlat = 0;
    var sumlong = 0;

    var poicount = 0;

    var some_points_on_screen = false;

    var points = new Array();

    search_results_poi.sort(function(a, b) { return a[2] == b[2] ? 0 : (a[2] < b[2] ? -1 : 1) })

    for (var i = search_results_poi.length - 1; i >= 0; i--) {
        var id = search_results_poi[i][0];
        var name = search_results_poi[i][1];
        var lat = search_results_poi[i][2];
        var mylong = search_results_poi[i][3];
        var type = search_results_poi[i][4];
        var showlevel = search_results_poi[i][5];

        lat = parseFloat(lat);
        mylong = parseFloat(mylong);

        if (type == "poi") {
            markPoint(id, name, lat, mylong);
            sumlat += lat;
            sumlong += mylong;
            poicount++;
            points[points.length] = [mylong, lat];
        }

        if (!some_points_on_screen) {
            //alert(lat + ", " + mylong + " is in (" + visible_min_latitude + ", " + visible_min_longitude + ") - (" + visible_max_latitude + ", " + visible_max_longitude + ")");
            if (lat > visible_min_latitude && lat < visible_max_latitude &&
						mylong > visible_min_longitude && mylong < visible_max_longitude) {
                some_points_on_screen = true;
            }
        }
    }

    if (sumlat != 0 && sumlong != 0) {
        if (zoomout_even_if_onscreen || !some_points_on_screen) {
            mmmap.setZoom(mmmap.findAppropriateZoom(points));
            //mmmap.moveTo(sumlat/poicount , sumlong/poicount);
        }
    }
}

function poiClicked(e) {
    highLightPOI(this.poi_id);

    mmmap.updateMouseCursorLocation();

    // FIXME right now supports only one popup
    if (typeof (mmmap.popupinfo[0]) == 'undefined') {
        mmmap.popupinfo[0] = new Object();
    }

    // save _lat, _long, ..... to this.popupinfo[this.popupinfo.length]
    // FIXME now supports only popup_idx = 0
    var popup_idx = 0;
    mmmap.popupinfo[popup_idx].lat = pointToLat(mouse_cursor_y, resolution);
    mmmap.popupinfo[popup_idx].lon = pointToLong(mouse_cursor_x, resolution);

    showLocationDetailPopup(this.poi_id, this.title, pointToLong(mouse_cursor_x, resolution), pointToLat(mouse_cursor_y, resolution), '', popup_idx);

    if (window.showLocationDetail) {
        showLocationDetail(this.poi_id, popup_idx);
    } else {
        mmmap.showLocationDetail(this.poi_id, popup_idx);
    }

    // NOT propagate the event
    if (!e) var e = window.event;
    return cancelEvent(e);
}

function clearCurrentRoads() {
    current_roads = new Array();
    MMMapclearLines();
}

function showCurrentRoads(movetocenter) {
    // draw the current roads using points store in current_roads_points variable

    if (!current_roads || current_roads.length == 0) {
        return;
    }

    MMMapclearLines();

    var sumlat = 0;
    var sumlong = 0;
    var totalpoints = 0;

    for (var r = 0; r < current_roads.length; r++) {
        var current_roads_points = current_roads[r];

        if (!current_roads_points || current_roads_points.length == 0) {
            return;
        }

        var xs = new Array();
        var ys = new Array();

        var i_inring = 0;
        var line_color = "#000000"; // black

        for (var i = 0; i < current_roads_points.length; i++) {
            if (i != 0 && current_roads_points[i].ring == 1) {
                // starting new ring, plot the old one
                if (line_color == "#0000ff") {
                    MMMapdrawLines(xs, ys, line_color, 3);
                } else {
                    MMMapdrawDoubleLines(xs, ys, line_color, 6);
                    //MMMapdrawLines(xs,ys,line_color,3);
                }

                // reset
                i_inring = 0;
                xs = new Array();
                ys = new Array();
            }

            xs[i_inring] = current_roads_points[i].mylong;
            ys[i_inring] = current_roads_points[i].lat;

            if (current_roads_points[i].status == "B") {
                line_color = "#0000ff"; // blue
            } else if (current_roads_points[i].status == "R") {
                line_color = "#ff0000"; // red
            } else if (current_roads_points[i].status == "G") {
                line_color = "#00ff00"; // green
            } else if (current_roads_points[i].status == "Y") {
                line_color = "#ffff00"; // yellow
            }

            sumlat += parseFloat(current_roads_points[i].lat);
            sumlong += parseFloat(current_roads_points[i].mylong);

            // last ring
            if (i == current_roads_points.length - 1) {
                if (line_color == "#0000ff") {
                    MMMapdrawLines(xs, ys, line_color, 3);
                } else {
                    MMMapdrawDoubleLines(xs, ys, line_color, 6);
                }
            }

            i_inring++;
            totalpoints++;
        }

    }

    if (movetocenter) {
        //alert("Moving to " + sumlat/totalpoints + ", " + sumlong/totalpoints);
        mmmap.moveTo(sumlat / totalpoints, sumlong / totalpoints);
    }
}

/*
* If info == "" it will try to retrieve node info from the network using the given ID (if not -1 or "")
* NOT zoom into the POI by default
*/
function markPOI(id, name, lat, mylong, showlevel, info) {
    markPOIandZoom(id, name, lat, mylong, showlevel, info, 0);
}

function markPOIandZoom(id, name, lat, mylong, showlevel, info, dozoom, maxwidth, maxheight, fixpopupsize) {
    if (mmmap.currentmode == "gmap") return;
    //showMMMap();
    if (id != -1)
        markPoint(id, name, lat, mylong);

    showlevel = Math.pow(2, showlevel);

    if (dozoom == 1) {
        if (showlevel > resolution) {
            mmmap.setRes(showlevel);
        }
        mmmap.moveTo(lat, mylong);
    }

    // check within the visible area
    if ((lat < visible_min_latitude || lat > visible_max_latitude) ||
			(mylong < visible_min_longitude || mylong > visible_max_longitude)) {
        mmmap.moveTo(lat, mylong);
    }

    // FIXME right now supports only one popup
    if (!mmmap.popupinfo[0]) {
        mmmap.popupinfo[0] = new Object();
    }

    // save _lat, _long, ..... to this.popupinfo[this.popupinfo.length]
    // FIXME now supports only popup_idx = 0
    var popup_idx = 0;
    mmmap.popupinfo[popup_idx].lat = lat;
    mmmap.popupinfo[popup_idx].lon = mylong;
    mmmap.popupinfo[popup_idx].maxwidth = maxwidth;
    mmmap.popupinfo[popup_idx].maxheight = maxheight;
    mmmap.popupinfo[popup_idx].fixpopupsize = (fixpopupsize) ? fixpopupsize : false; // true:equal, false:maxwidth,maxheight

    showLocationDetailPopup(id, name, mylong, lat, '', popup_idx);

    if (info == "" && id != "" && id > 0) {
        // get from network
        if (window.showLocationDetail) {
            showLocationDetail(id, popup_idx);
        } else {
            mmmap.showLocationDetail(id, popup_idx);
        }
    } else {
        // otherwise just print what I have
        showDiv("locationdetails_contents", info);

        //setTimeout("set_popup_div_size('" + info + "','" + popup_idx + "');",400);
        mmmap_set_popup_div_size(popup_idx);
    }
}

function do_rightclick() {
    if (showRightClickPopup) {
        showRightClickPopup(mouse_cursor_x, mouse_cursor_y);
    }
    return false;
}

var do_scroll_timer;

function do_scroll(e) {
    mmmap.disableMouseWheel();

    var wheelDelta;

    e = e ? e : window.event;

    if (e.wheelDelta) { /* IE/Opera. */
        wheelDelta = e.wheelDelta;
        if (window.opera)
            wheelDelta = -wheelDelta;
    } else {
        wheelDelta = e.detail * -120;
    }

    if (mmmap && (mmmap.currentmode == "mm" || mmmap.currentmode == "hybrid") && window.myX && window.myY) {
        var zoomDivX = myX - document.getElementById("zooming_image_div").offsetWidth / 2;
        var zoomDivY = myY - document.getElementById("zooming_image_div").offsetHeight / 2;

        document.getElementById("zooming_image_div").style.left = zoomDivX + "px";
        document.getElementById("zooming_image_div").style.top = zoomDivY + "px";

        document.getElementById("zooming_image_div").style.visibility = "visible";
        setTimeout('document.getElementById("zooming_image_div").style.visibility="hidden"', 1000);

        var newlat = pointToLat(myY - findPosY(mymap), resolution);
        var newlong = pointToLong(myX - findPosX(mymap), resolution);

        var newresolution;

        if (wheelDelta >= 0) {
            newlat = (parseFloat(newlat) + parseFloat(mmmap.centerLat())) / 2;
            newlong = (parseFloat(newlong) + parseFloat(mmmap.centerLong())) / 2;

            newresolution = resolution * 2;

        } else {
            newlat = (-parseFloat(newlat) + 2 * parseFloat(mmmap.centerLat()));
            newlong = (-parseFloat(newlong) + 2 * parseFloat(mmmap.centerLong()));

            newresolution = resolution / 2;
        }

        if (!(newresolution > max_resolution || newresolution < min_resolution)) {
            if (do_scroll_timer) {
                clearTimeout(do_scroll_timer);
            }

            var mycommand = "mmmap.moveTo(" + newlat + "," + newlong + ");mmmap.setRes(" + newresolution + ");";

            if (mmmap.mouseWheelHandler) mycommand += "mmmap.mouseWheelHandler();";
            do_scroll_timer = setTimeout(mycommand, 50);
        }

    } else if (mmmap.currentmode == "gmap") {
        muteWheel(gmap, do_scroll); // until we process everything
        setTimeout('acceptWheel(gmap,do_scroll)', 200);

        if (wheelDelta >= 0) {
            gmap.gmap_object.zoomIn();
        } else {
            gmap.gmap_object.zoomOut();
        }
    }

    cancelEvent(e);

    //setTimeout('mmmap.enableMouseWheel()', 50); // this cause scroll event propagation problem
    mmmap.enableMouseWheel();
}
