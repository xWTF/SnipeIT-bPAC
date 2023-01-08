# Snipe-IT bPAC Daemon

![](https://img.shields.io/github/license/xWTF/SnipeIT-bPAC)
![](https://img.shields.io/badge/It%20Works-On%20My%20Machine%E2%84%A2%EF%B8%8F-green)

## Usage

1. Create a template with P-touch Editor following [The Official Guide](https://support.brother.com/g/s/es/dev/en/bpac/use/editor/index.html), set the `Object Name` column to one of the [Keys Available](#Keys-Available), they will be replaced automatically :)
1. Save the template file to a sensible location
1. Install the [bPAC Client Component](https://support.brother.com/g/s/es/dev/en/bpac/download/index.html#client) on the server that runs this daemon
1. Grab the daemon from [releases](https://github.com/xWTF/SnipeIT-bPAC/releases) or build your own from the source
1. Open the daemon, click **Stop** button and configure a sensible port and access key, and the template file
1. Click **Start** button
1. Overwrite the **labels.blade.php** in your Snipe-IT installation
1. Go create some label, you will see a button and asset list instead of labels
1. Click the print button and it should work :)

## Start with Windows

Create a shortcut in `shell:startup` folder.

## Start minimized

Just pass `-m` to the argument list.

# The Snipe-IT part

## Keys Available

All keys are prepended with a prefix (e.g. `S: ` for serial) except for `asset_tag` and `id`.

| Key       | Description                |
| --------- | -------------------------- |
| id        | The asset ID               |
| name      | Name of asset              |
| serial    | Serial number              |
| model     | Model name                 |
| company   | Company name               |
| asset_tag | The asset tag, for 1D-code |

## labels.blade.php

Replace `resources/views/hardware/labels.blade.php` with content below.

Specifically, if you're using docker, mount it to `/var/www/html/resources/views/hardware/labels.blade.php`.

```php
<?php
define('ACCESS_KEY', 'YOUR-ACCESS-KEY-HERE');
define('SERVER_ENDPOINT', 'http://127.0.0.1:8000/print');

$labels = [];
foreach ($assets as $asset) {
    $labels[] = [
        'id' => 'ID: ' . $asset->id,
        'name' =>  empty($asset->name) ? '' : 'N: ' . $asset->name,
        'serial' => empty($asset->serial) ? '' : 'S: ' . $asset->serial,
        'model' => empty($asset->model->name) ? '' : 'M: ' . $asset->model->name,
        'company' => $asset->company === null ? null : 'C: ' . $asset->company->name,
        'asset_tag' => $asset->asset_tag,
    ];
}
?>

<!doctype html>
<html lang="en">

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Labels Print</title>
</head>

<body>
    <div style="display: flex;flex-flow: column;gap: 12px">
        <span>Labels Data: <?php echo count($labels); ?></span>
        <div>
            <button type="button" id="print" onclick="doPrint()">Click here to print</button>
        </div>
        <ul style="margin: 0;">
            <?php
            foreach ($labels as $l) {
                echo ('<li>' . $l['id'] . ', ' . $l['asset_tag'] . ', ' . $l['model'] . '</li>');
            }
            ?>
        </ul>
    </div>
    <script>
        function doPrint() {
            var el = document.getElementById('print');
            el.setAttribute('disabled', true);
            el.innerText = 'Requesting...';

            el = el.parentElement;

            fetch(<?php echo json_encode(SERVER_ENDPOINT); ?>, {
                    credentials: 'omit',
                    method: 'POST',
                    headers: {
                        'Authorization': 'Bearer <?php echo ACCESS_KEY; ?>',
                    },
                    // For readability
                    body: JSON.stringify(<?php echo json_encode($labels); ?>),
                }).then(r => r.text())
                .then(r => el.innerText = r)
                .catch(e => el.innerText = 'Error: ' + e);
        }
    </script>
</body>

</html>
```
