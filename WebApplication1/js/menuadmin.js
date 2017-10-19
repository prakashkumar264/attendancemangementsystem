document.write(
"<ul class=\"list\">" +
"                        <li class=\"header\">MAIN NAVIGATION</li>" +
"                        <li class=\"active\">" +
"                            <a href=\"@Url.Action(\"admin\", \"admin\")\">" +
"                                <i class=\"material-icons\">home</i>" +
"                                <span>Home</span>" +
"                            </a>" +
"                        </li>" +
"                        <li>" +
"                            <a href=\"javascript:void(0);\" class=\"menu-toggle\">" +
"                                <i class=\"material-icons\">content_copy</i>" +
"                                <span>Assign Teachers</span>" +
"                            </a>" +
"                            <ul class=\"ml-menu\">" +
"                                <li>" +
"                                    <a href=\"@Url.Action(\"Index\", \"assignteacher\")\">" +
"                                        <i class=\"material-icons\">view_list</i>" +
"                                        <span>Subject Teachers</span>" +
"                                    </a>" +
"                                </li>" +
"                                <li>" +
"                                    <a href=\"@Url.Action(\"Index\", \"assignpracteacher\")\">" +
"                                        <i class=\"material-icons\">view_list</i>" +
"                                        <span>Practical Teachers</span>" +
"                                    </a>" +
"                                </li>" +
"                            </ul>" +
"                        </li>" +
"                        <li>" +
"                            <a href=\"javascript:void(0);\" class=\"menu-toggle\">" +
"                                <i class=\"material-icons\">content_copy</i>" +
"                                <span>Teacher Records</span>" +
"                            </a>" +
"                            <ul class=\"ml-menu\">" +
"                                <li>" +
"                                    <a href=\"@Url.Action(\"Index\", \"teacherlists\")\">" +
"                                        <i class=\"material-icons\">mode_edit</i>" +
"                                        <span>Teacher Details</span>" +
"                                    </a>" +
"                                </li>" +
"                                <li>" +
"                                    <a href=\"@Url.Action(\"Register\", \"Register\")\">" +
"                                        <i class=\"material-icons\">mode_edit</i>" +
"                                        <span>Register Teacher</span>" +
"                                    </a>" +
"                                </li>" +
"                            </ul>" +
"                        </li>" +
"                        <li>" +
"                            <a href=\"javascript:void(0);\" class=\"menu-toggle\">" +
"                                <i class=\"material-icons\">content_copy</i>" +
"                                <span>Theory Subject Records</span>" +
"                            </a>" +
"                            <ul class=\"ml-menu\">" +
"                                <li>" +
"                                    <a href=\"@Url.Action(\"Index\", \"subjectlists\")\">" +
"                                        <i class=\"material-icons\">mode_edit</i>" +
"                                        <span>Modify</span>" +
"                                    </a>" +
"                                </li>" +
"                                <li>" +
"                                    <a href=\"@Url.Action(\"uploadsubject\", \"uploadsubject\")\">" +
"                                        <i class=\"material-icons\">mode_edit</i>" +
"                                        <span>Add</span>" +
"                                    </a>" +
"                                </li>" +
"                            </ul>" +
"                        </li>" +
"                        <li>" +
"                            <a href=\"javascript:void(0);\" class=\"menu-toggle\">" +
"                                <i class=\"material-icons\">content_copy</i>" +
"                                <span>Practical Subject Records</span>" +
"                            </a>" +
"                            <ul class=\"ml-menu\">" +
"                                <li>" +
"                                    <a href=\"@Url.Action(\"Index\", \"subpracticallists\")\">" +
"                                        <i class=\"material-icons\">mode_edit</i>" +
"                                        <span>Modify</span>" +
"                                    </a>" +
"                                </li>" +
"                                <li>" +
"                                    <a href=\"@Url.Action(\"uploadsubpractical\", \"uploadsubpractical\")\">" +
"                                        <i class=\"material-icons\">mode_edit</i>" +
"                                        <span>Add </span>" +
"                                    </a>" +
"                                </li>" +
"                            </ul>" +
"                        </li>" +
"                        <li>" +
"                            <a href=\"@Url.Action(\"logout\", \"admin\")\">" +
"                                <i class=\"material-icons\">input</i>" +
"                                <span>LogOut</span>" +
"                            </a>" +
"                        </li>" +
"                    </ul>"
);