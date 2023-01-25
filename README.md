# Snipe-IT bPAC Daemon

![](https://img.shields.io/github/license/xWTF/SnipeIT-bPAC)
![](https://img.shields.io/badge/It%20Works-On%20My%20Machine%E2%84%A2%EF%B8%8F-green)

## Usage

1. Create a template with P-touch Editor following [The Official Guide](https://support.brother.com/g/s/es/dev/en/bpac/use/editor/index.html), set the `Object Name` column to one of the [Keys Available](#Keys-Available), they will be replaced automatically :)
1. Save the template file to a sensible location
1. Install the [bPAC Client Component](https://support.brother.com/g/s/es/dev/en/bpac/download/index.html#client) on the server that runs this daemon  
   __Note: If you are downloading from releases, get the 64 bit version!__
1. Grab the daemon from [releases](https://github.com/xWTF/SnipeIT-bPAC/releases) or build your own from the source
1. Open the daemon, click **Stop** button and configure a sensible port and access key, and the template file
1. Click **Start** button
1. Overwrite the **labels.blade.php** in your Snipe-IT installation
1. Go create some label, you will see a button and asset list instead of labels
1. Click the print button and it should work :)

## Start with Windows

Create a shortcut in `shell:startup` folder, and it should work.

To start miminized, pass `-m` to the argument list.

## Random freezes on request?

If you're facing random freezes after printing for a few times and idle for a long period, while continuous printing works fine, it might be a bPAC issue.

The **bPAC SDK 3.4 Manual**, **Troubleshooting** sections writes:

> ### It is taking a long time to run Open()
> With Open(), printer enumeration is performed internally.  
> If a printer with slow response is connected, for example, a printer on the network that is turned off, Open () can take a long time.

Possible solutions:

- Connect your printer via USB instead of WLAN
- Kill the program when it stuck, and reopen it & re-submit the print request  
  This is 100% working & fast, the first print request after freeze ALWAYS works
- Wait patiently, in my worst case it takes 3 minutes to execute the `Open()` method
- Try to mess with the config tool and make the printer not sleep

## The Snipe-IT part

### Keys Available

All keys are prepended with a prefix (e.g. `S:` for serial) except for `asset_tag` and `asset_url`.

| Key       | Description                |
| --------- | -------------------------- |
| id        | The asset ID               |
| name      | Name of asset              |
| serial    | Serial number              |
| model     | Model name                 |
| company   | Company name               |
| asset_tag | The asset tag, for 1D-code |
| asset_url | The asset URL, for 2D-code |

### Install labels.blade.php

Take a look at [labels.blade.php](./labels.blade.php), modify the top `define` lines according to your configuration. The first PHP codeblock is dead simple, you may modify it according to your needs too.

Then, replace `resources/views/hardware/labels.blade.php` with it, and you're good to go.

Specifically, if you're using docker, mount it to `/var/www/html/resources/views/hardware/labels.blade.php`.
