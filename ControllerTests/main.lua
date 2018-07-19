function love.load( ... )
	love.window.setFullscreen(true)
	love.mouse.setVisible(false)
end

function love.draw()
	love.graphics.setColor(255,255,255)
	local joysticks = love.joystick.getJoysticks()
	for _,j in ipairs(joysticks) do
		local x = j:getAxis(1)
		local y = j:getAxis(2)
		x = love.graphics.getWidth()*((x+1)/2)
		y = love.graphics.getHeight()*((y+1)/2)
		love.graphics.circle(j:isDown(1) and "fill" or "line",x, y, 20)
		love.graphics.print(j:getName(), x+25,y-15)
		for b=1,j:getButtonCount() do
			local ang = lerp(0, -math.pi*1.5, (b+1)/j:getButtonCount())
			local ox = math.cos(-ang)*30
			local oy = math.sin(-ang)*30
			love.graphics.circle(j:isDown(b) and "fill" or "line",x+ox,y+oy,5)
		end
	end
end

function lerp(a, b, n)
	return b*n + a*(1-n)
end



