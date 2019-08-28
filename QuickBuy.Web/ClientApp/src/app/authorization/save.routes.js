"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var SaveRoutes = /** @class */ (function () {
    function SaveRoutes() {
    }
    SaveRoutes.prototype.canActivate = function (route, state) {
        //se usuario autenticado
        return true;
    };
    return SaveRoutes;
}());
exports.SaveRoutes = SaveRoutes;
//# sourceMappingURL=save.routes.js.map