<?php

function Checkbox($name, $id, $checked = 0,$onchange="")
{
    // DESCRIPTION:
    // Returns a Checkbox Form-Element
    // $name    Form-Element-Name
    // $id      Unique ID. Required since it uses a label
    // $checked Default: 0. Sets the checkbox to checked (1)

    return '<input type="checkbox" name="'.$name.'" id="'.$id.'" onchange="'.$onchange.'" class="slidecheckbox" '.(($checked) ? 'checked' : '').'/><label class="checkbox_toggle_lable" for="'.$id.'">Toggle</label>';
}

function Tickbox($name, $id, $text, $checked = false,$onchange="")
{
    // DESCRIPTION:
    // Returns a Checkbox Form-Element
    // $name    Form-Element-Name
    // $id      Unique ID. Required since it uses a label
    // $text    Text shown next to the Tickbox
    // $checked Default: 0. Sets the checkbox to checked (1)

    return '<div class="tickbox"><input type="checkbox" name="'.$name.'" id="'.$id.'" onchange="'.$onchange.'" '.(($checked) ? 'checked' : '').'/><label for="'.$id.'">'.$text.'</label></div>';
}

function Togglebox($name, $id, $checked = 0,$onchange="",$sessionName="")
{
    // DESCRIPTION:
    // Returns a Checkbox Form-Element
    // $name    Form-Element-Name
    // $id      Unique ID. Required since it uses a label
    // $checked Default: 0. Sets the checkbox to checked (1)

    return '
        <script>
            $(window).on("load", function () {
                if(window.sessionStorage.getItem("'.$sessionName.'")==null) window.sessionStorage.setItem("'.$sessionName.'",'.$checked.');
                CheckToggleSession("'.$id.'","'.$sessionName.'");
                '.$onchange.'
            });
        </script>

        <input type="checkbox" name="'.$name.'" id="'.$id.'" onchange="'.$onchange.'" class="togglecheckbox" '.(($checked) ? 'checked' : '').'/><label class="checkbox_toggle2_lable" for="'.$id.'">Toggle</label>
    ';
}

function RadioButton($title, $name, $checked = 0,$value="",$onchange="")
{
    // DESCRIPTION:
    // Returns a Radio-Button Form-Element
    // $title   Text beside the Radio-Button
    // $name    Form-Element-Name
    // $checked Default: 0. Sets the Button to checked (1)

    return '
        <label class="radiolabel">'.$title.'
            <input type="radio" value="'.$value.'" id="'.$name.'" name="'.$name.'" '.(($checked) ? 'checked' : '').' onchange="'.$onchange.'">
            <span class="radiocheckmark"></span>
        </label>
    ';
}

function FileButton($name, $id, $multiple=false, $onchange="", $onclick="",$style="",$required=false,$presetValue = "")
{
    // DESCRIPTION:
    // Returns a File-Upload Form-Element
    // $name      Form-Element-Name
    // $id        Unique ID. Required since it uses a label
    // $multiple  Default: 0. Defines if multiple files can be selected

    return  '
        <input type="file" value="'.$presetValue.'" name="'.$name.'[]" id="'.$id.'" class="inputfile" data-multiple-caption="{count} Dateien" '.(($multiple) ? 'multiple' : '').' '.(($onchange!="") ? ('onchange="'.$onchange.'"') : '').' hidden '.($required ? 'required' : '').'/>
        <label for="'.$id.'" '.(($onclick!="") ? ('onclick="'.$onclick.'"') : '').' style="'.$style.'"><svg xmlns="http://www.w3.org/2000/svg" width="20" height="17" viewBox="0 0 20 17"><path d="M10 0l-5.2 4.9h3.3v5.1h3.8v-5.1h3.3l-5.2-4.9zm9.3 11.5l-3.2-2.1h-2l3.4 2.6h-3.5c-.1 0-.2.1-.2.1l-.8 2.3h-6l-.8-2.2c-.1-.1-.1-.2-.2-.2h-3.6l3.4-2.6h-2l-3.2 2.1c-.4.3-.7 1-.6 1.5l.6 3.1c.1.5.7.9 1.2.9h16.3c.6 0 1.1-.4 1.3-.9l.6-3.1c.1-.5-.2-1.2-.7-1.5z"/></svg> <span style="color:#FEFEFE;">'. ($multiple ? 'Dateien' : 'Datei') .' ausw&auml;hlen</span></label>
        <script src="/js/filebutton.js"></script>
    ';
}

function ColorPicker($name, $id, $text, $value, $lifeChangeId="",$DOMproperty="style.color",$onchange="")
{
    // DESCRIPTION:
    // Returns a Color-Picker Form-Element
    // $name            Form-Element-Name
    // $id              Unique ID. Required
    // $text            Text inside the Button
    // $value           Color-Value (Hex)
    // $lifeChangeId    ID of the element to which the color should instantly be applied
    // $DOMproperty     DOM-Property to set the target that should be changed

    $idu = uniqid();

    return '
            '.(($lifeChangeId != "") ? ('<script> function JSColorUpdate'.$idu.'(jscolor) { document.getElementById("'.$lifeChangeId.'").'.$DOMproperty.' = "#" + jscolor } </script>') : '').'
        <input name="'.$name.'" type="hidden" id="'.$id.'" value="'.$value.'" '.(($onchange!="") ? ('onchange="'.$onchange.'"') : '').'>
        <button class="jscolor {'.(($lifeChangeId != "") ? ('onFineChange:\'JSColorUpdate'.$idu.'(this);\',') : '').'valueElement: \''.$id.'\',width:260, height:200, position:\'right\',borderColor:\'#FFF\', insetColor:\'#FFF\', backgroundColor:\'#666\'}" value="'.$value.'">'.$text.'</button>
    ';
}

function TextareaPlus($name, $id="edit", $placeholder="",$required = false, $minControlls = false)
{
    $retval = '

        <textarea name="'.$name.'" id="'.$id.'" style="margin-top: 30px;display:none;" '.($required ? 'required' : '').'>
            '.$placeholder.'
        </textarea>


        ';

        if(!$minControlls)
        {
            $retval .= '

                <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.3.0/codemirror.min.js"></script>
                <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.3.0/mode/xml/xml.min.js"></script>

                <script type="text/javascript" src="/js/froala/plugins/char_counter.min.js"></script>
                <script type="text/javascript" src="/js/froala/plugins/code_beautifier.min.js"></script>
                <script type="text/javascript" src="/js/froala/plugins/code_view.min.js"></script>
                <script type="text/javascript" src="/js/froala/plugins/fullscreen.min.js"></script>
                <script type="text/javascript" src="/js/froala/plugins/link.min.js"></script>
                <script type="text/javascript" src="/js/froala/plugins/save.min.js"></script>
                <script type="text/javascript" src="/js/froala/plugins/url.min.js"></script>
                <script type="text/javascript" src="/js/froala/plugins/video.min.js"></script>
                <script type="text/javascript" src="/js/froala/plugins/file.min.js"></script>
                <script type="text/javascript" src="/js/froala/plugins/table.min.js"></script>
                <script type="text/javascript" src="/js/froala/plugins/quick_insert.min.js"></script>
                <script type="text/javascript" src="/js/froala/plugins/paragraph_format.min.js"></script>
                <script type="text/javascript" src="/js/froala/plugins/paragraph_style.min.js"></script>
                <script type="text/javascript" src="/js/froala/plugins/image.min.js"></script>
                <script type="text/javascript" src="/js/froala/plugins/entities.min.js"></script>
                <script type="text/javascript" src="/js/froala/plugins/quote.min.js"></script>
                <script type="text/javascript" src="/js/froala/plugins/link.min.js"></script>
                <script type="text/javascript" src="/js/froala/plugins/lists.min.js"></script>
                <script type="text/javascript" src="/js/froala/plugins/font_size.min.js"></script>
                <script type="text/javascript" src="/js/froala/plugins/font_family.min.js"></script>
                <script type="text/javascript" src="/js/froala/plugins/line_breaker.min.js"></script>
                <script type="text/javascript" src="/js/froala/plugins/inline_style.min.js"></script>
                <script type="text/javascript" src="/js/froala/plugins/image_manager.min.js"></script>
            ';
        }

    $retval .= '

        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>


        <script type="text/javascript" src="/js/froala/froala_editor.min.js" ></script>
        <script type="text/javascript" src="/js/froala/plugins/align.min.js"></script>
        <script type="text/javascript" src="/js/froala/plugins/colors.min.js"></script>
        <script type="text/javascript" src="/js/froala/plugins/draggable.min.js"></script>
        <script type="text/javascript" src="/js/froala/plugins/emoticons.min.js"></script>

        <script>
            $(function(){
                $("#'.$id.'").froalaEditor()
                .on("froalaEditor.image.beforeUpload", function (e, editor, files) {
                    if (files.length) {
                        var reader = new FileReader();
                        reader.onload = function (e) {
                            var result = e.target.result;

                            editor.image.insert(result, null, null, editor.image.get());
                        };

                        reader.readAsDataURL(files[0]);
                    }

                    return false;
                })
            });
        </script>
    ';

    return $retval;
}

function FroalaContent($content)
{
    return '<div class="fr-view fr-element">'.$content.'</div>';
}

?>