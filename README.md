# Snipe-IT bPAC Daemon

## Usage

Install the [bPAC Client Component](https://support.brother.com/g/s/es/dev/en/bpac/download/index.html#client) on the server that runs this daemon.

(TODO: Write detailed guide)

## Start with Windows

Create a shortcut in `shell:startup` folder.

## Start minimized

Just pass `-m` to the argument list.

# labels.blade.php

Replace `resources/views/hardware/labels.blade.php` with content below:

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
