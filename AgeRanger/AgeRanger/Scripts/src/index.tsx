import * as React from "react";
import * as ReactDOM from "react-dom";

import { AgeRanger } from "./components/ageranger";

ReactDOM.render(
    <AgeRanger url='person' submitUrl='person/new' />,
    document.getElementById("ageranger")
);
